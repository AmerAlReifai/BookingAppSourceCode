using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class HotelPricingInfo
    {
        public string averagePriceValue { get; set; }
        public string totalPriceValue { get; set; }
        public string crossOutPriceValue { get; set; }
        public string originalPricePerNight { get; set; }
        public string currency { get; set; }
        public string percentSavings { get; set; }
        public string drr { get; set; }
    }
}