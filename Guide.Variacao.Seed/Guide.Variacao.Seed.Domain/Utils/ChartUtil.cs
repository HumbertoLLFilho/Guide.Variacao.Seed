using Guide.Variacao.Core.Domain.Models;
using Guide.Variacao.Seed.Core.Models;
using TradingPeriod = Guide.Variacao.Core.Domain.Models.TradingPeriod;

namespace Guide.Variacao.Seed.Domain.Utils
{
    public static class ChartUtil
    {
        /// <summary>
        /// Create a List of Stock based on a List of charts.
        /// </summary>
        /// <param name="charts">The chat to transform into a Stock</param>
        /// <returns>An Stock list</returns>
        public static List<Stock> ToStocks(this List<Chart> charts)
        {
            var stocks = new List<Stock>();
            
            foreach (Chart chart in charts)
                stocks.Add(chart.ToStock());
            
            return stocks;
        }

        /// <summary>
        /// Create a Stock based on the chart.
        /// </summary>
        /// <param name="chart">The chat to transform into a Stock</param>
        /// <returns>An Stock</returns>
        public static Stock ToStock(this Chart chart)
        {
            var result = chart.Result[0];

            var meta = result.Meta;

            var stock = new Stock()
            {
                Currency = meta.Currency,
                DataGranularity = meta.DataGranularity,
                Symbol = meta.Symbol,
                Range = meta.Range,
            };

            var timestamps = result.Timestamp;

            var quote = result.Indicators.Quote[0];

            var quotesHigh = quote.High;
            var quotesLow = quote.Low;
            var quotesOpen = quote.Open;
            var quotesClose = quote.Close;
            var quotesVolume = quote.Volume;

            for (int i = 0; i < timestamps.Count; i++)
            {
                var auction = new Auction()
                {
                    StockId = stock.Id,

                    TimeStamp = DateTime.UnixEpoch.AddSeconds(timestamps[i]),
                    High = quotesHigh[i] ?? 0,
                    Low = quotesLow[i] ?? 0,
                    Open = quotesOpen[i] ?? 0,
                    Close = quotesClose[i] ?? 0,
                    Volume = quotesVolume[i] ?? 0,
                };

                stock.Auctions.Add(auction);
            }

            var currentTradindPeriod = result.Meta.CurrentTradingPeriod;

            AddTradingPeriod(stock, currentTradindPeriod.Pre);
            AddTradingPeriod(stock, currentTradindPeriod.Regular);
            AddTradingPeriod(stock, currentTradindPeriod.Post);


            return stock;
        }

        private static Stock AddTradingPeriod<T>(Stock stock, T period) where T : Core.Models.TradingPeriod
        {
            stock.TradingPeriods.Add(new TradingPeriod()
            {
                StockId = stock.Id,

                Start = DateTime.UnixEpoch.AddSeconds(period.Start),
                End = DateTime.UnixEpoch.AddSeconds(period.End),
                Offset = period.GmtOffset,
                TimeZone = period.Timezone,
            });

            return stock;
        }
    }
}
