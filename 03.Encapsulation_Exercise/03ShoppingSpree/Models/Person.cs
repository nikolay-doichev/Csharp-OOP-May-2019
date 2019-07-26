﻿using _03ShoppingSpree.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }
        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
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
        public decimal Money
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeMoneyException);
                }
                this.money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            decimal moneyLeft = this.Money - product.Cost;

            if (moneyLeft < 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CannotAffordAProductException, this.Name, product.Name));
            }

            this.Money = moneyLeft;
            this.bag.Add(product);
        }
        public override string ToString()
        {
            if (this.bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {string.Join(", ", bag)}";
        }
    }
}
