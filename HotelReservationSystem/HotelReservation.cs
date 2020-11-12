using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    class HotelReservation
    {
        public static Dictionary<string, HotelDetails> onlineHotelRecords = new Dictionary<string, HotelDetails>();

        /// <summary>
        /// UC1
        /// Add Hotels.
        /// </summary>
        /// <param name="hotelName">Name of the hotel.</param>
        /// <param name="ratePerDay">The rate per day.</param>
        public static void AddHotelRecords(string hotelName, int ratePerDay)
        {
            if (onlineHotelRecords.ContainsKey(hotelName))
            {
                Console.WriteLine("Hotel already exists.");
            }
            else
            {
                HotelDetails newHotel = new HotelDetails(hotelName, ratePerDay);
                onlineHotelRecords.Add(hotelName, newHotel);
            }
        }
        /// <summary>
        /// Displays the Hotels in dictionary.
        /// </summary>
        public static void DisplayRecordsInDictionary()
        {
            foreach (var records in onlineHotelRecords)
            {
                Console.WriteLine($"Hotel Name = {records.Key}, Rate Per Day = {records.Value.ratePerDay}\n");
            }
        }
    }
}
