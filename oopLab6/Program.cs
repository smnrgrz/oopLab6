using System;
using System.Linq;
public class Product
{
    private double price;
    public string ProductCode { get; init; }
    public string Name { get; set; }
    public int Stock { get; private set; }

    public double Price
    {
        get { return price; }
        set
        {
            if(value>0)
            {
                price = value;
            }
            else
            {
                Console.WriteLine($"invalid price:{value}");
                price= 1.0;
            }
        }
    }

    public Product( string productCode,string name,double price,int stock)
    {
        ProductCode = productCode;
        Name = name;
        Price = price;  
        Stock = stock;
    }

    public void Restock(int amount)
    {
        Stock += amount;
    }
    public void Info()
    {
        Console.WriteLine($"\nProductCode:{ProductCode}, Name:{Name}, Price:${Price:F2}, Stock:{Stock}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Product[] products = {
            new Product("P101", "Wireless Mouse", 25.50, 15),
            new Product("P102", "Mechanical Keyboard", 85.00, 10),
            new Product("P103", "USB-C Cable", 1.00, 50),
            new Product("P104", "Gaming Monitor", 220.00, 50)
    };


        Console.WriteLine("Products:");
        foreach (var product in products)
        {
            product.Info();
        }

        products[0].Restock(5);
        products[1].Restock(8);
        Console.WriteLine("\nAfter restocking:\n");
        products[0].Info();
        products[1].Info();


        double minPrice = products.Min(p => p.Price);
        double maxPrice = products.Max(p => p.Price);
        double avgPrice = products.Average(p => p.Price);

        Console.WriteLine($"\nMinimum Price: {minPrice:F2}");
        Console.WriteLine($"Maximum Price: {maxPrice:F2}");
        Console.WriteLine($"Average Price: {avgPrice:F2}");

        Console.WriteLine("\nProducts >= $50:");
        var expensiveProducts = products.Where(p => p.Price >= 50);
        foreach (var product in expensiveProducts)
        {
            product.Info();
        }

        Console.WriteLine("\nSorted Prices (low to high):");
        var sortedAsc = products
            .Select(p => p.Price)
            .OrderBy(price => price);
        foreach (var price in sortedAsc)
        {
            Console.WriteLine($"${price:F2}");
        }
           
        int index = Array.FindIndex(products, p => p.Price == 85);

        Console.WriteLine("\nSearch:");
        if (index != -1)
            Console.WriteLine($"Found: 85 at index {index}");
       
    }
}
