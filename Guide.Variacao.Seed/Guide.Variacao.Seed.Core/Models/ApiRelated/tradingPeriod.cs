using System;

namespace Guide.Variacao.Seed.Core.Models
{
    public class TradingPeriod
    {
        public string Timezone { get; set; }
        public double Start { get; set; }
        public double End { get; set; }
        public double GmtOffset { get; set; }

        public static DateTime ToDate(double unixTime) =>
            DateTime.UnixEpoch.AddSeconds(unixTime);
    }
}
