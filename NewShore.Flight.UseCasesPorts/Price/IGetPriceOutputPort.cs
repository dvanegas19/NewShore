using NewShore.Flight.UsesCasesDTOs.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Flight.UseCasesPorts.Price
{
    public interface IGetPriceOutputPort
    {
        Task GetPrice(List<GetPriceParams> ListGetPrice);
    }
}
