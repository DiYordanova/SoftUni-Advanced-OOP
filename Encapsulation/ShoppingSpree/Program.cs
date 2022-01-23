using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();
            try
            {
                people = ReadPeople();
                products = ReadProducts();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] parts = line.Split();

                string personName = parts[0];
                string productName = parts[1];

                var person = people[personName];
                var product = products[productName];

                try
                {
                    person.AddProduct(product);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }
        }

        private static Dictionary<string, Product> ReadProducts()
        {
            Dictionary<string, Product> result = new Dictionary<string, Product>();
            string[] parts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                string[] productData = part.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string productName = productData[0];
                decimal cost = decimal.Parse(productData[1]);
                result[productName] = new Product(productName, cost);

            }
            return result;
        }

        private static Dictionary<string, Person> ReadPeople()
        {
            Dictionary<string, Person> result = new Dictionary<string, Person>();
            string[] parts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                string[] personData = part.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = personData[0];
                decimal money = decimal.Parse(personData[1]);
                result[name] = new Person(name, money);
            }

            return result;
        }
    }
}
