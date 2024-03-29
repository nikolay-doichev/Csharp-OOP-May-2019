﻿using System;

namespace PlayersAndMonsters.Common
{
    public static class Validator
    {
        public static void ThrowIfIntegerIsbelowZero(int value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfStringIsNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw  new ArgumentException(message);
            }
        }
    }
}