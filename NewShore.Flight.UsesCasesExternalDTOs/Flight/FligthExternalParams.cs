﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Flight.UsesCasesExternalDTOs.Flight
{
    public class FligthExternalParams
    {
        public string departureStation { get; set; }

        public string arrivalStation { get; set; }

        public string flightCarrier { get; set; }

        public string flightNumber { get; set; }

        public double price { get; set; }
    }
}
