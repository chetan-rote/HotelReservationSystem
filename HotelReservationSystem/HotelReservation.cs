using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageExt;

namespace HotelReservationSystem
{
    class HotelReservation
    {
        /// Dictionary to stores the record of the hotel and the totalExpense of the hotel.
        public static Dictionary<string, HotelDetails> onlineHotelRecords = new Dictionary<string, HotelDetails>();

        /// <summary>
        /// UC1
        /// Adds hotels to dictionary
        /// </summary>
        /// <param name="hotelName"></param>
        /// <param name="weekdayRate"></param>
        /// <param name="weekendRate"></param>
        /// <param name="rating"></param>
        public static void AddHotelRecords(string hotelName, int weekdayRate, int weekendRate, int rating)
        {
            if (onlineHotelRecords.ContainsKey(hotelName))
            {
                Console.WriteLine("Hotel already exists.");
            }
            else
            {
                HotelDetails newHotel = new HotelDetails(hotelName, weekdayRate, weekendRate, rating);
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
                    $" {records.Value.weekdayRate}, Weekend Rate Per Day = {records.Value.weekendRate}," +
                    $" Ratings = {records.Value.rating}\n");
            }
        }
        /// <summary>
        /// UC4 & 6
        /// Find cheapest best rated hotel for the customer in date range.
        /// </summary>
        /// <param name="checkInDate"></param>
        /// <param name="checkOutDate"></param>
        /// <returns></returns>
        public static Tuple<string, int, int> FindCheapestBestRatedHotels(DateTime checkInDate, DateTime checkOutDate)
        {
            try
            {                
                /// Computing the number ofdays of stay requested by the customer
                int noOfDaysOfStay = (checkOutDate - checkInDate).Days + 1;
                /// Dictionary to store the (rateperday*numberofdaysofStay) and name of the hotel as the key
                Dictionary<string, int> rateRecords = new Dictionary<string, int>();
                /// Dictionary to store the (ratings) and name of the hotel as the key
                Dictionary<string, int> ratingRecords = new Dictionary<string, int>();
                /// Adding the rating and hotel name to the dictionary
                foreach (var records in onlineHotelRecords)
                {
                    ratingRecords.Add(records.Value.hotelName, records.Value.rating);
                }
                /// Sorting the dictionary element by the rating in descending order
                var keyValueForSortedRating = ratingRecords.OrderByDescending(sortedValuePair => sortedValuePair.Value);
                /// Iterating over the online hotel records to store the total expense and hotel name
                foreach (var records in onlineHotelRecords)
                {
                    int totalExpense = 0;
                    DateTime currentDate = checkInDate;
                    while (currentDate <= checkOutDate)
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
                var keyValueForSortedByRate = rateRecords.OrderBy(keyValueForSorted => keyValueForSorted.Value);
                /// Getting the length of the sorted dictionary for rating
                int length = (keyValueForSortedRating.Length() / 2);
                /// Deciding the median amply rated hotel for the user
                var ratings = keyValueForSortedRating.ElementAt(length);
                /// Declaring a tuple to return name of hotel, rate and rating
                Tuple<string, int, int> outputHotel;
                /// Matching for amply rated and cheapest hotel too
                foreach (var sortByRate in keyValueForSortedByRate)
                {
                    /// Condition check for the most suitable hotel according to  the use cases
                    if (sortByRate.Key == ratings.Key)
                    {
                        outputHotel = new Tuple<string, int, int>(sortByRate.Key, sortByRate.Value, ratings.Value);
                       // flag = true;
                        return outputHotel;
                    }
                }                
            }
            catch (HotelReservationCustomException e)
            {
                Console.WriteLine(e.Message);
            }            
            return new Tuple<string, int, int>("", 0, 0);
        }
    }
}
