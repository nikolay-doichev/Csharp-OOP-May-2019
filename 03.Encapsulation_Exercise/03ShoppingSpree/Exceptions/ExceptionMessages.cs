using System;
using System.Collections.Generic;
using System.Text;

namespace _03ShoppingSpree.Exceptions
{
    public static class ExceptionMessages
    {
        public static string NullOrEmptyException =
            "Name cannot be empty";

        public static string NegativeMoneyException =
            "Money cannot be negative";

        public static string CannotAffordAProductException =
            "{0} can't afford {1}";
    }
}
