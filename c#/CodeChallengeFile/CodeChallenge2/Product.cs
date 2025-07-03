using System;
using System.Collections.Generic;

class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
}

class Program2
{
    static void Main()
    {
        List<Product> products = new List<Product>();

        for (int i = 0; i < 10; i++)
        {
            Product product = new Product();
            Console.WriteLine($"Enter details for Product {i + 1}:");

            while (true)
            {
                Console.Write("Product ID: ");
                try
                {
                    product.ProductId = int.Parse(Console.ReadLine());
                    break; 
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid integer for Product ID.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number is too large or too small for an integer.");
                }
            }

      
            Console.Write("Product Name: ");
            product.ProductName = Console.ReadLine();

   
            while (true)
            {
                Console.Write("Price: ");
                try
                {
                    product.Price = double.Parse(Console.ReadLine());
                    break; 
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number for Price.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Invalid input. The number is too large or too small for a double.");
                }
            }

            products.Add(product);
        }

        products.Sort((x, y) => x.Price.CompareTo(y.Price));

        Console.WriteLine("Sorted Products by Price:");

        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.Price}");
        }

        Console.Read();
    }
}
