using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Hotel
    {
        public OfferDateRange offerDateRange { get; set; }
        public Destination destination { get; set; }
        public HotelInfo hotelInfo { get; set; }
        public HotelPricingInfo hotelPricingInfo { get; set; }
        public HotelUrls hotelUrls { get; set; }

    }
}