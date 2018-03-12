using BookingApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BookingApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult BookingInfo(string HotelName = "", string City = "", string Currency = "", string Province = "", int? lengthOfStay = null, int? minStarRating = null, int? maxStarRating = null, int? minGuestReviewRating = null, int? maxGuestReviewRating = null, int? minHotelReviewTotal = null, int? maxHotelReviewTotal = null)
        {
            var json = new WebClient().DownloadString("https://offersvc.expedia.com/offers/v2/getOffers?scenario=deal-finder&page=foo&uid=foo&productType=Hotel");
            OffersDetails OffersDetails = DeserializeJson<OffersDetails>(json);
            ViewBag.OfferList = OffersDetails.offers.Hotel;
            ViewBag.OfferInfoTitle = "Offer Information.";
            ViewBag.OfferInfo = OffersDetails.offerInfo;
            ViewBag.userInfo = OffersDetails.userInfo;
            ViewBag.userInfoTitle = "User Info.";
            // return View(OffersDetails.offers.Hotel);
            List<Hotel> Hotel = OffersDetails.offers.Hotel;
            if (!(string.IsNullOrWhiteSpace(HotelName) &&
                string.IsNullOrWhiteSpace(City) &&
                string.IsNullOrWhiteSpace(Currency) &&
                string.IsNullOrWhiteSpace(Province))
                )
                Hotel = Hotel.Where(c => true &&
                ((!string.IsNullOrWhiteSpace(HotelName) && c.hotelInfo.hotelName.ToUpper().Contains(HotelName.ToUpper())) || string.IsNullOrWhiteSpace(HotelName))
               && ((!string.IsNullOrWhiteSpace(City) && c.hotelInfo.hotelCity.ToUpper().Contains(City.ToUpper())) || string.IsNullOrWhiteSpace(City))
               && ((!string.IsNullOrWhiteSpace(Currency) && c.hotelPricingInfo.currency.ToUpper().Contains(Currency.ToUpper())) || string.IsNullOrWhiteSpace(Currency))
               && ((!string.IsNullOrWhiteSpace(Province) && c.hotelInfo.hotelProvince.ToUpper().Contains(Province.ToUpper())) || string.IsNullOrWhiteSpace(Province))


                ).ToList();

            if (lengthOfStay.HasValue)
                Hotel = Hotel.Where(c => true && (!lengthOfStay.HasValue || (Convert.ToInt32(c.offerDateRange.lengthOfStay) == lengthOfStay.Value))).ToList();

            if (minStarRating.HasValue)
                Hotel = Hotel.Where(c => true && (Convert.ToDecimal(c.hotelInfo.hotelStarRating) >= minStarRating.Value || !minStarRating.HasValue)).ToList();
            if (maxStarRating.HasValue)
                Hotel = Hotel.Where(c => true && (Convert.ToDecimal(c.hotelInfo.hotelStarRating) <= maxStarRating.Value || !maxStarRating.HasValue)).ToList();
            if (minGuestReviewRating.HasValue)
                Hotel = Hotel.Where(c => true && (Convert.ToDecimal(c.hotelInfo.hotelGuestReviewRating) >= minGuestReviewRating.Value || !minGuestReviewRating.HasValue)).ToList();

            if (maxGuestReviewRating.HasValue)
                Hotel = Hotel.Where(c => true && (Convert.ToDecimal(c.hotelInfo.hotelGuestReviewRating) <= maxGuestReviewRating.Value || !maxGuestReviewRating.HasValue)).ToList();

            if (minHotelReviewTotal.HasValue)
                Hotel = Hotel.Where(c => true && (Convert.ToDecimal(c.hotelInfo.hotelReviewTotal) >= minHotelReviewTotal.Value || !minHotelReviewTotal.HasValue)).ToList();

            if (maxHotelReviewTotal.HasValue)
                Hotel = Hotel.Where(c => true && (Convert.ToDecimal(c.hotelInfo.hotelReviewTotal) <= maxHotelReviewTotal.Value || !maxHotelReviewTotal.HasValue)).ToList();

            return View(Hotel);
        }
         public OffersDetails pOffersDetails { get; set; }
                
        public ActionResult BookingInfo()
        {
            //UserInfo cc = new UserInfo();
            var json = new WebClient().DownloadString("https://offersvc.expedia.com/offers/v2/getOffers?scenario=deal-finder&page=foo&uid=foo&productType=Hotel");          
            OffersDetails OffersDetails = DeserializeJson<OffersDetails>(json);
            pOffersDetails = OffersDetails;
            string xx=Encoding.GetEncoding(1252).GetString(HttpUtility.UrlDecodeToBytes(OffersDetails.offers.Hotel.First().hotelUrls.hotelInfositeUrl));
            //string cc = HttpUtility.(OffersDetails.offers.Hotel.First().hotelUrls.hotelInfositeUrl);
            ViewBag.OfferList = OffersDetails.offers.Hotel;
            ViewBag.OfferInfoTitle = "Offer Information.";
            ViewBag.OfferInfo = OffersDetails.offerInfo;
            ViewBag.userInfo = OffersDetails.userInfo;
            ViewBag.userInfoTitle = "User Info.";

            return View(OffersDetails.offers.Hotel);
        }
        [HttpPost]
        public ActionResult Update(string id, string productid, int qty, decimal unitrate) {
            return View();
        }
        public string getDate(int year, int month, int day)
        {
            DateTime newDate = new DateTime(year, month, day);
            return newDate.ToString("ddMMyyyy");
        }

        public static T DeserializeJson<T>(string input)
        {
            var result = JsonConvert.DeserializeObject(input);
            var result2 = JsonConvert.DeserializeObject(result.ToString());
            return JsonConvert.DeserializeObject<T>(result2.ToString());
        }
    }
}