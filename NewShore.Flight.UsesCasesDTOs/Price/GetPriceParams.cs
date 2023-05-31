using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Flight.UsesCasesDTOs.Price
{
    public class GetPriceParams
    {
        public double Price { get; set; }

        public string CurrencyType { get; set; }

        public bool Active { get; set; }
    }
}
