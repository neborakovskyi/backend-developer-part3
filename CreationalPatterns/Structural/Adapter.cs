using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Structural
{
    public interface IAnalyticsLibrary
    {
        string RequestJson();
    }

    public class StockDataProvider
    {
        public string RequestXml()
        {
            return "get Xml";
        }
    }

    public class AdapterStockDataProviderToAnalyticsLibrary : IAnalyticsLibrary
    {
        private readonly StockDataProvider _stockDataProvider;

        public AdapterStockDataProviderToAnalyticsLibrary(StockDataProvider stockDataProvider)
        {
            _stockDataProvider = stockDataProvider;
        }

        public string RequestJson()
        {
            var data = _stockDataProvider.RequestXml();
            return $"({data}) is converted to Json";
        }
    }
}
