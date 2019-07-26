using _03ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03ShoppingSpree.Core
{
    public class Engine
    {
        private List<Person> persons;
        private List<Product> products;
        public Engine()
        {
            this.persons = new List<Person>();
            this.products = new List<Product>();
        }
        public void Run()
        {
            try
            {
                ReadPersonsInput();
                ReadProductInput();                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    string[] commandTokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string personName = commandTokens[0];
                    string productName = commandTokens[1];

                    Person person = this.persons.FirstOrDefault(p => p.Name == personName);
                    Product product = this.products.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        person.BuyProduct(product);
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                    
                }
                catch (InvalidOperationException iow)
                {
                    Console.WriteLine(iow.Message);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(Environment.NewLine, this.persons));
        }

        private void ReadProductInput()
        {
            string[] productsInput = Console.ReadLine()
                                        .Split(";", StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

            foreach (var pt in productsInput)
            {
                string[] productsInfo = pt
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = productsInfo[0];
                decimal cost = decimal.Parse(productsInfo[1]);

                Product product = new Product(name, cost);

                this.products.Add(product);

            }
        }

        private void ReadPersonsInput()
        {
            string[] personTokens = Console.ReadLine()
                            .Split(";", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

            foreach (var pt in personTokens)
            {
                string[] personInfo = pt
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);

                Person person = new Person(name, money);

                this.persons.Add(person);
            }
        }
    }
}
