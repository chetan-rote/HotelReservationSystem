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
        /// UC3
        /// Differentiating between the weekday and weekend rates.
        public int weekdayRate;
        public int weekendRate;
        /// <summary>
        /// Parameterised Constructor to initialise the instance of the Hotel Details By the value passed by user
        /// </summary>
        /// <param name="hotelName"></param>
        /// <param name="ratePerDay"></param>
        public HotelDetails(string hotelName, int weekdayRate, int weekendRate)
        {
            this.hotelName = hotelName;
            this.weekdayRate = weekdayRate;
            this.weekendRate = weekendRate;
        }
    }
}
