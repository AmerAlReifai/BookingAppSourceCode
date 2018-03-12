using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class HotelInfo
    {
        public string hotelId { get; set; }
        public string hotelName { get; set; }
        public string localizedHotelName { get; set; }
        public string hotelDestination { get; set; }
        public string hotelDestinationRegionID { get; set; }
        public string hotelLongDestination { get; set; }
        public string hotelStreetAddress { get; set; }
        public string hotelCity { get; set; }
        public string hotelProvince { get; set; }
        public string hotelCountryCode { get; set; }
        public string hotelLatitude { get; set; }
        public string hotelLongitude { get; set; }
        public string hotelStarRating { get; set; }
        public string hotelGuestReviewRating { get; set; }
        public string hotelReviewTotal { get; set; }
        public string hotelImageUrl { get; set; }
        public string vipAccess { get; set; }
        public string isOfficialRating { get; set; }
    }
}