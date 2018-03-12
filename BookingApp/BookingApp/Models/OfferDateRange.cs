using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class OfferDateRange
    {
        public string getFullDate(List<string> dateList)
        {
            if (dateList.Count == 3)
            {
                DateTime newDate = new DateTime(Convert.ToInt32(dateList[0]), Convert.ToInt32(dateList[1]), Convert.ToInt32(dateList[2]));
                return newDate.ToString("dd/MM/yyyy");
            }
            else
                return "";
        }
        public List<string> travelStartDate { get; set; }
        public List<string> travelEndDate { get; set; }
        public string lengthOfStay { get; set; }
    }
   
}