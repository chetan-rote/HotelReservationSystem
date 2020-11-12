using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    class HotelDetails
    {
        ///Variables.
        public string hotelName;
        /// UC3
        /// Differentiating between the weekday and weekend rates.
        public int weekdayRate;
        public int weekendRate;
        /// UC5
        /// Adding the rating to each hotel.
        public int rating;
        /// <summary>
        /// Parameterised Constructor to initialise the instance of the Hotel Details By the value passed by user
        /// </summary>
        /// <param name="hotelName"></param>
        /// <param name="ratePerDay"></param>
        public HotelDetails(string hotelName, int weekdayRate, int weekendRate, int rating)
        {
            this.hotelName = hotelName;
            this.weekdayRate = weekdayRate;
            this.weekendRate = weekendRate;
            this.rating = rating;
        }
    }
}
