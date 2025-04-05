// Program 2: Encapsulation (Online Ordering)
// This program will:
    // Store product details.
    // Store customer and address details.
    // Calculate the total order cost.
    // Generate packing and shipping labels.

using System;
using System.Collections.Generic;

// The Product class encapsulates details of a product
class Product
{
    // Private fields
    private string _name;
    private string _productID;
    private double _price;
    private int _quantity;

    // Constructor to initialize product details
    public Product(string name, string productID, double price, int quantity)
    {
        _name = name;
        _productID = productID;
        _price = price;
        _quantity = quantity;
    }

    // Method to calculate the total price of the product (price * quantity)
    public double GetTotalPrice()
    {
        return _price * _quantity;
    }

    // Override ToString to return a formatted string for the product
    public override string ToString()
    {
        return $"{_name} (ID: {_productID}) - ${_price} x {_quantity} = ${GetTotalPrice()}";
    }
}

// The Address class encapsulates address details
class Address
{
    // Private fields
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    // Constructor to initialize address details
    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    // Method to check if the address is within the USA
    public bool IsUSA()
    {
        return _country.ToLower() == "usa";
    }

    // Override ToString to return a formatted string for the address
    public override string ToString()
    {
        return $"{_street}, {_city}, {_state}, {_country}";
    }
}

// The Customer class encapsulates customer details
class Customer
{
    // Private fields
    private string _name;
    private Address _address;

    // Constructor to initialize customer details
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Method to get customer info as a string
    public string GetCustomerInfo()
    {
        return $"{_name}, {_address}";
    }
}

// The Order class encapsulates order processing logic
class Order
{
    // Private fields
    private List<Product> _products;
    private Customer _customer;

    // Constructor to initialize order details
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to calculate the total order cost
    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalPrice();
        }
        if (!_customer.Address.IsUSA())
        {
            total += 5.0; // Add international shipping fee
        }
        return total;
    }

    // Method to generate the packing label for the order
    public void GeneratePackingLabel()
    {
        Console.WriteLine("Packing Label:");
        foreach (var product in _products)
        {
            Console.WriteLine($"- {product}");
        }
        Console.WriteLine();
    }

    // Method to generate the shipping label for the order
    public void GenerateShippingLabel()
    {
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(_customer.GetCustomerInfo());
        Console.WriteLine();
    }
}

// The main program to test the Order, Customer, and Product classes
class Program
{
    static void Main()
    {
        // Create customer and address
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        // Create an order for the customer
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "L123", 1200, 1));
        order1.AddProduct(new Product("Mouse", "M456", 25, 2));

        // Generate packing and shipping labels for the order
        order1.GeneratePackingLabel();
        order1.GenerateShippingLabel();
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");
    }
}
