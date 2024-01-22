namespace Guide.Variacao.Seed.Core.Models
{
    public static class Stocks
    {
        private readonly static List<string> _StocksList =
        [
            "PETR4.SA",
            "VALE3.SA",
            "BBAS3.SA",
            "BBDC4.SA",
            "ITSA4.SA",
            "USIMS.SA",
            "CSNA3.SA",
            "SBSP3.SA",
            "SBSP3.SA",
            "BTC-USD",
            "AMZN"
        ];

        public static List<string> Get() => _StocksList;
    }
}
