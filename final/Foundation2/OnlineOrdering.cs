// Program 2: Encapsulation (Online Ordering)
// This program will:
    // Store product details.
    // Store customer and address details.
    // Calculate the total order cost.
    // Generate packing and shipping labels.

    using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; private set; }
    public string ProductID { get; private set; }
    public double Price { get; private set; }
    public int Quantity { get; private set; }

    public Product(string name, string productID, double price, int quantity)
    {
        Name = name;
        ProductID = productID;
        Price = price;
        Quantity = quantity;
    }

    public double GetTotalPrice()
    {
        return Price * Quantity;
    }

    public override string ToString()
    {
        return $"{Name} (ID: {ProductID}) - ${Price} x {Quantity} = ${GetTotalPrice()}";
    }
}

class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsUSA()
    {
        return Country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

class Customer
{
    public string Name { get; private set; }
    public Address Address { get; private set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public string GetCustomerInfo()
    {
        return $"{Name}, {Address}";
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalPrice();
        }
        if (!customer.Address.IsUSA())
        {
            total += 5.0; // International shipping fee
        }
        return total;
    }

    public void GeneratePackingLabel()
    {
        Console.WriteLine("Packing Label:");
        foreach (var product in products)
        {
            Console.WriteLine($"- {product}");
        }
        Console.WriteLine();
    }

    public void GenerateShippingLabel()
    {
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(customer.GetCustomerInfo());
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "L123", 1200, 1));
        order1.AddProduct(new Product("Mouse", "M456", 25, 2));

        order1.GeneratePackingLabel();
        order1.GenerateShippingLabel();
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");
    }
}
