namespace DanskeLiveCode;

class Program
{
    private static readonly string[] currencies =  { "DKK", "SEK", "EUR", "USD" };

    static void Main(string[] args)
    {
        Thread RiskProviderThread = new(Provider);
        RiskProviderThread.Start();

        Console.WriteLine("Done");
    }

    static void Provider()
    {
        Console.WriteLine("Provider");
        Random rand = new(45684);

        List<string> trades = new();
        for (int i = 0; i < 20; i++)
        {
            string TradeWithRisk = "TradeID: " + i + ", Risk: " + rand.NextDouble() * 1000 + ", currency: " + currencies[i % 4];
            trades.Add(TradeWithRisk);
        }

        Reporter(trades);
    }

    static void Reporter(List<string> trades)
    {
        Console.WriteLine("Reporter");

        foreach (var tradeWithRisk in trades)
        {
            Console.WriteLine(tradeWithRisk);
        }
    }

    // Price of base currency in quote currency, e.g. 1 EUR cost 7.4534 DKK
    static double GetExchangeRate(string baseCcy, string quoteCcy)
    {
        if (baseCcy != "EUR")
        {
            throw new ArgumentException("Base currency expected to be EUR, was: "+baseCcy);
        }
        switch (quoteCcy)
        {
            case "DKK":
                return 7.4534;
            case "SEK":
                return 11.199;
            case "USD":
                return 1.0953;
            default:
                throw new ArgumentException("Unknown quote currency: "+quoteCcy);
        }
    }
}
