using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalFarm.Exceptions
{
    public static class ExceptionMessages
    {
        public static string NullOrEmptyException =
            "Name cannot be empty.";

        public static string InvalidAgeException =
            "Age should be between 0 and 15.";
    }
}
