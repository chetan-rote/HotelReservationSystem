
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
        public static void FunctionForCustomerType(int type)
        {
            HotelReservation.FindCheapestHotel(type);
            HotelReservation.FindCheapestBestRatedHotels(type);
            HotelReservation.FindBestRatedHotel(type);
        }
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
           
            Console.WriteLine("Hello Welcome to Hotel Reservation System\n");
            HotelReservation.DefiningAdditionRepository(CustomerType.REGULAR);
            HotelReservation.DefiningAdditionRepository(CustomerType.REWARD);
            HotelReservation.DisplayRecordsInDictionary();
            Console.WriteLine("Have you upgraded from the regular customer then enter yes.");
            string choice = Console.ReadLine().ToLower();
            if (choice == "yes")
            {
                FunctionForCustomerType(2);
            }
            else
            {
                FunctionForCustomerType(1);
            }
            Console.ReadKey();
        }
    }
}
