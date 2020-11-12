using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageExt;

namespace HotelReservationSystem
{
    class HotelReservation
    {
        /// Dictionary to store the record of the hotel and the hotel details for regular customers.
        public static Dictionary<string, HotelDetails> recordsForRegularCutomers = new Dictionary<string, HotelDetails>();
        /// Dictionary to store the record of the hotel and the hotel details for reward customers.
        public static Dictionary<string, HotelDetails> recordsForRewardCutomers = new Dictionary<string, HotelDetails>();
        public static void DefiningAdditionRepository(CustomerType customerType)
        {
            switch (customerType)
            {
                /// Adding the detail for the regular customer type
                case CustomerType.REGULAR:
                    AddHotelRecords("Lakewood", 110, 90, 3, 1);
                    AddHotelRecords("Bridgewood", 150, 50, 4, 1);
                    AddHotelRecords("Ridgewood", 220, 150, 5, 1);
                    break;
                /// Adding the detail for the rewarded customer type
                case CustomerType.REWARD:
                    AddHotelRecords("Lakewood", 80, 80, 3, 2);
                    AddHotelRecords("Bridgewood", 110, 50, 4, 2);
                    AddHotelRecords("Ridgewood", 100, 40, 5, 2);
                    break;
                /// Catching the exception for the invalid customer type
                default:
                    throw new HotelReservationCustomException(HotelReservationCustomException.ExceptionType.INVALID_CUSTOMER_TYPE, "Does not support this customer type");
            }
        }
        public static void AddHotelRecords(string hotelName, int weekdayRate, int weekendRate, int rating, int type)
        {
            if (type == 1)
            {
                if (recordsForRegularCutomers.ContainsKey(hotelName))
                {
                    Console.WriteLine("Record Already exists. Kindly enter a different record...");
                }
                else
                {
                    HotelDetails newHotelRecord = new HotelDetails(hotelName, weekdayRate, weekendRate, rating);
                    recordsForRegularCutomers.Add(hotelName, newHotelRecord);
                }
            }
            else
            {
                if (recordsForRewardCutomers.ContainsKey(hotelName))
                {
                    Console.WriteLine("Record Already exists. Kindly enter a different record...");
                }
                else
                {
                    HotelDetails newHotelRecord = new HotelDetails(hotelName, weekdayRate, weekendRate, rating);
                    recordsForRewardCutomers.Add(hotelName, newHotelRecord);
                }
            }
        }
        /// <summary>
        /// Displays the Hotels in dictionary.
        /// </summary>
        public static void DisplayRecordsInDictionary()
        {
            /// Displaying the record for the Regular Customers            
            Console.WriteLine(" Regular Customers Detail for the Hotel List ");
            foreach (var records in recordsForRegularCutomers)
            {
                Console.WriteLine($"Hotel Name = {records.Key}, WeekDay Rate Per Day = {records.Value.weekdayRate}, WeekDay Rate Per Day = {records.Value.weekendRate}, Ratings = {records.Value.rating}\n");
            }
            /// Displaying the record for the Rewarded Customers
            Console.WriteLine(" Rewarded Customers Detail for the Hotel List ");
            foreach (var records in recordsForRewardCutomers)
            {
                Console.WriteLine($"Hotel Name = {records.Key}, WeekDay Rate Per Day = {records.Value.weekdayRate}, WeekDay Rate Per Day = {records.Value.weekendRate}, Ratings = {records.Value.rating}\n");
            }
        }

        public static Dictionary<string, int> CalculateTotalRateForEachHotel(int type)
        {
            /// Getting the check-in date or the start date
            Console.WriteLine("Enter the check in date this format DD-MM-YYYY.");
            string startDate = Console.ReadLine();
            DateTime checkInDate = DateTime.Parse(startDate);
            /// Getting the check-in date or the start date
            Console.WriteLine("Enter the check out date in this format DD-MM-YYYY.");
            string endDate = Console.ReadLine();
            DateTime checkOutDate = DateTime.Parse(endDate);
            /// Dictionary to store the calculated rate for each hotel.
            Dictionary<string, int> rateRecords = new Dictionary<string, int>();
            /// Computing the number ofdays of stay requested by the customer
            int noOfDaysOfStay = (checkOutDate - checkInDate).Days + 1;
            /// Iterating over the online hotel records to store the total expense and hotel name
            foreach (var records in ((type == 1)? recordsForRegularCutomers : recordsForRewardCutomers))
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
            return rateRecords;
        }

        public static void FindCheapestHotel(int type)
        {
            /// Catching the exception of null value to the sorted list
            try
            {
                /// Refactor - Fixing the voilation of Dry Principle by calculating the total fare using a method call
                Dictionary<string, int> rateRecords = new Dictionary<string, int>();
                rateRecords = CalculateTotalRateForEachHotel(type);
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
        /// <summary>
        /// UC6 -- Find cheapest best rated hotel for the customer date range of travel
        /// Logic -- Consider the cheapest if it is high in rating and low in cost
        /// Else consider the second next in cost reduction
        /// </summary>
        /// <returns></returns>
        public static void FindCheapestBestRatedHotels(int type)
        {
            try
            {
                /// Refactor - Fixing the voilation of Dry Principle by calculating the total fare using a method call
                Dictionary<string, int> rateRecords = new Dictionary<string, int>();
                rateRecords = CalculateTotalRateForEachHotel(type);
                /// Dictionary to store the rating Records and name of dictionary
                Dictionary<string, int> ratingRecords = new Dictionary<string, int>();
                /// Adding the rating and hotel name to the dictionary
                foreach (var records in ((type == 1) ? recordsForRegularCutomers : recordsForRewardCutomers))
                {
                    ratingRecords.Add(records.Value.hotelName, records.Value.rating);
                }
                /// Sorting the dictionary element by the rating in descending order
                var keyValueForSortedRating = ratingRecords.OrderByDescending(sortedValuePair => sortedValuePair.Value);
                /// Executing the order by total expense and fetching the minimum value of rate
                var keyValueForSortedByRate = rateRecords.OrderBy(keyValueForSorted => keyValueForSorted.Value);
                /// Getting the length of the sorted dictionary for rating
                int length = (keyValueForSortedRating.Length() / 2);
                /// Deciding the median amply rated hotel for the user
                var ampleRating = keyValueForSortedRating.ElementAt(length);                
                /// Matching for rating and cheapest hotel too
                foreach (var sortByRate in keyValueForSortedByRate)
                {
                    /// Condition check for the most suitable hotel according to  the use cases
                    if (sortByRate.Key == ampleRating.Key)
                    {
                        Console.WriteLine("Cheapest Hotel is: {0} with Rates: {1} and Ratings: {2}.", sortByRate.Key, sortByRate.Value);
                    }
                }               
            }
            catch (HotelReservationCustomException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// UC7 -- Find the best rated hotel and its cost for a given date range
        /// </summary>
        /// <returns></returns
        public static void FindBestRatedHotel(int type)
        {
            ///To store calculated rates for hotels.
            Dictionary<string, int> rateRecords = new Dictionary<string, int>();
            rateRecords = CalculateTotalRateForEachHotel(type);
            /// Dictionary to store the rating Records and name of dictionary
            Dictionary<string, int> ratingRecords = new Dictionary<string, int>();
            /// Adding the rating and hotel name to the dictionary
            foreach (var records in ((type == 1) ? recordsForRegularCutomers : recordsForRewardCutomers))
            {
                ratingRecords.Add(records.Value.hotelName, records.Value.rating);
            }
            /// Sorting the dictionary element by the rating in descending order.
            var keyValueForSortedRating = ratingRecords.OrderByDescending(sortedValuePair => sortedValuePair.Value).First();
            ///Iterating the rating dictionary.
            foreach (var sortByRate in rateRecords)
            {
                /// Condition check for the most suitable hotel according to  the use cases
                if (sortByRate.Key == keyValueForSortedRating.Key)
                {
                    Console.WriteLine("Best Rated hotel is: {0} with Rates: {1} and Ratings: {2}.", sortByRate.Key, sortByRate.Value, keyValueForSortedRating.Value);
                }
            }
        }
    }
}
