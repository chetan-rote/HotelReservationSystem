using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    class HotelReservationCustomException : Exception
    {
        public enum ExceptionType
        {
            RATE_ENTRY_NOT_EXIST,
            NO_SUCH_HOTEL,
            INVALID_DATES,
            INVALID_CUSTOMER_TYPE
        }
        /// <summary>
        /// Creating an instance of the exception type to initailise with value
        /// </summary>
        public ExceptionType type;
        /// <summary>
        /// Custom Exception to override the base exception message
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public HotelReservationCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
