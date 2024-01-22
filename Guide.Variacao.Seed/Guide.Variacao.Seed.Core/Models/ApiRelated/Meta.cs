namespace Guide.Variacao.Seed.Core.Models
{
    public class Meta
    {
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public string ExchangeName { get; set; }
        public string InstrumentType { get; set; }
        public int FirstTradeDate { get; set; }
        public int RegularMarketTime { get; set; }
        public int GmtOffset { get; set; }
        public string Timezone { get; set; }
        public string ExchangeTimezoneName { get; set; }
        public double RegularMarketPrice { get; set; }
        public double ChartPreviousClose { get; set; }
        public double PreviousClose { get; set; }
        public int Scale { get; set; }
        public int PriceHint { get; set; }
        public CurrentTradingPeriod CurrentTradingPeriod { get; set; }
        public List<List<TradingPeriod>> TradingPeriods { get; set; }
        public string DataGranularity { get; set; }
        public string Range { get; set; }
        public List<string> ValidRanges { get; set; }
    }
}
