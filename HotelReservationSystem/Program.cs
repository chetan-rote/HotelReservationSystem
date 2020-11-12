
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
            HotelReservation.AddHotelRecords("Lakewood", 110, 90);
            HotelReservation.AddHotelRecords("Bridgewood", 150, 50);
            HotelReservation.AddHotelRecords("Ridgewood", 220, 150);
            /// Display the record in the hotel record dictionary.
            HotelReservation.DisplayRecordsInDictionary();
            /// UC 2
            /// Print the hotel with the cheapest rates.
            HotelReservation.FindCheapestHotel();
            Console.ReadKey();
        }
    }
}
