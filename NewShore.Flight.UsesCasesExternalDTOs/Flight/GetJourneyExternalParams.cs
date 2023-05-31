using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Flight.UsesCasesExternalDTOs.Flight
{
    public class GetJourneyExternalParams
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public double Price { get; set; }

        public List<GetFlightExternalParams> Flights { get; set; }

    }
}
