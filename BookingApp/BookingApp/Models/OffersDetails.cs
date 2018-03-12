using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class OffersDetails
    {
        public OfferInfo offerInfo { get; set; }
        public UserInfo userInfo { get; set; }
        public Offers offers { get; set; }


    }
}