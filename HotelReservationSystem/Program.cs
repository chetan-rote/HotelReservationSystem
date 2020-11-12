
/******************************************************************************
 *  Purpose: Hotel Rservation System to view book the hotel room.
 *
 *
 *  @author  Chetan Rote
 *  @version 1.0
 *  @since   11-11-2020
 ******************************************************************************/
using System;

namespace HotelReservationSystem
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Welcome to Hotel Reservation System\n");
            /// UC1 
            /// Adding the hotels name and rates.
            HotelReservation.AddHotelRecords("Lakewood", 110, 90, 3);
            HotelReservation.AddHotelRecords("Bridgewood", 150, 50, 4);
            HotelReservation.AddHotelRecords("Ridgewood", 220, 150, 5);
            /// Display the record in the hotel record dictionary.
            HotelReservation.DisplayRecordsInDictionary();
            /// Getting the check-in date or the start date
            Console.WriteLine("Enter the check in date this format DD-MM-YYYY.");
            string startDate = Console.ReadLine();
            DateTime checkInDate = DateTime.Parse(startDate);
            /// Getting the check-in date or the start date
            Console.WriteLine("Enter the check out date in this format DD-MM-YYYY.");
            string endDate = Console.ReadLine();
            DateTime checkOutDate = DateTime.Parse(endDate);
            ///UC-7 Finds the best rated hotel.
            HotelReservation hotelReservation = new HotelReservation();
            hotelReservation.FindBestRatedHotel(checkInDate, checkOutDate);
            Console.ReadKey();
        }
    }
}
