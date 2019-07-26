﻿using _03ShoppingSpree.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03ShoppingSpree.Models
{
    public class Product
    {
        private string name;

        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullOrEmptyException);
                }
                this.name = value;
            }
        }
        public decimal Cost
        {
            get { return this.cost; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeMoneyException);
                }
                this.cost = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
