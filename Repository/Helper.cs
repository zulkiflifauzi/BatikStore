using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository
{
    public static class Helper
    {
        public static IEnumerable<Product> GetRandomFromList(this IEnumerable<Product> type, int maxCount)
        {
            Random random = new Random(DateTime.Now.Millisecond);

            Dictionary<double, Product> randomSortTable = new Dictionary<double, Product>();

            foreach (Product item in type)
                randomSortTable[random.NextDouble()] = item;

            return randomSortTable.OrderBy(KVP => KVP.Key).Take(maxCount).Select(KVP => KVP.Value);
        }

    }
}