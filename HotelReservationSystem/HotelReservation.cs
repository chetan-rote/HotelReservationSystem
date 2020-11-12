using System;
using System.Collections.Generic;
using System.Linq;
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
        public static void AddHotelRecords(string hotelName, int weekdayRate, int weekendRate)
        {
            if (onlineHotelRecords.ContainsKey(hotelName))
            {
                Console.WriteLine("Hotel already exists.");
            }
            else
            {
                HotelDetails newHotel = new HotelDetails(hotelName, weekdayRate, weekendRate);
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
                Console.WriteLine($"Hotel Name = {records.Key}, WeekDay Rate Per Day =" +
                    $" {records.Value.weekdayRate}, Weekend Rate Per Day = {records.Value.weekendRate}\n");
            }
        }
        /// <summary>
        /// UC2 & 4
        /// Finds the cheapest hotel for the date range.
        /// </summary>
        public static void FindCheapestHotel()
        {
            try
            {
                /// Getting the check in date or the start date.
                Console.WriteLine("Enter the booking date(DD-MM-YYYY):");
                DateTime checkInDate = DateTime.Parse(Console.ReadLine());
                /// Getting the check out date or the end date.
                Console.WriteLine("Enter the check-out date(DD-MM-YYYY):");
                DateTime checkoutDate = DateTime.Parse(Console.ReadLine());
                /// Computing the number ofdays of stay requested by the customer
                int noOfDays = (checkoutDate - checkInDate).Days + 1;
                /// Dictionary to store the (rateperday*numberofdaysofStay) and name of the hotel as the key
                Dictionary<string, int> rateRecords = new Dictionary<string, int>();
                /// Iterating over the online hotel records to store the total expense and hotel name
                foreach (var records in onlineHotelRecords)
                {
                    int totalExpense = 0;
                    DateTime currentDate = checkInDate;
                    while (currentDate <= checkoutDate)
                    {
                        /// Checking the type of the date - Weekend (Saturday or Sunday)
                        if (currentDate.Equals("Saturday") || currentDate.Equals("Sunday"))
                        {
                            /// Adding the weekend expense in the total expense
                            totalExpense += records.Value.weekendRate;
                        }
                        else
                        {
                            /// Adding the weekday expense in the total expense
                            totalExpense += records.Value.weekdayRate;
                        }
                        /// Moving to the next day to increment the current date
                        currentDate = currentDate.AddDays(1);
                    }
                    rateRecords.Add(records.Value.hotelName, totalExpense);
                }
                /// Executing the order by total expense and fetching the minimum value of rate
                var keyValueForSorted = rateRecords.OrderBy(keyValueForSorted => keyValueForSorted.Value).First();
                /// Returning the custom sized null exception for no entry of the rate value
                if (keyValueForSorted.Key == null)
                    throw new HotelReservationCustomException(HotelReservationCustomException.ExceptionType.RATE_ENTRY_NOT_EXIST, "There was no total Expense entry for the cheapest hotel.");
                Console.WriteLine("Cheapest Hotel - {0}, Cheapest Rate - {1}", keyValueForSorted.Key, keyValueForSorted.Value);
            }
            catch (HotelReservationCustomException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
