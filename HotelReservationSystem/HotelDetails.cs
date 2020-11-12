using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    class HotelDetails
    {
        ///Variables.
        public string hotelName;
        public int ratePerDay;
        /// <summary>
        /// Parameterised Constructor to initialise the instance of the Hotel Details By the value passed by user
        /// </summary>
        /// <param name="hotelName"></param>
        /// <param name="ratePerDay"></param>
        public HotelDetails(string hotelName, int ratePerDay)
        {
            this.hotelName = hotelName;
            this.ratePerDay = ratePerDay;
        }
    }
}
