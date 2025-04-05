using System;

// The Address class encapsulates event location details
class Address
{
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

    // Method to return the address in a formatted string
    public override string ToString()
    {
        return $"{_street}, {_city}, {_state}, {_country}";
    }
}

// The base Event class contains common properties for all event types
class Event
{
    // Private fields
    private string _title;
    private string _description;
    private DateTime _date;
    private string _time;
    private Address _address;

    // Constructor to initialize event details
    public Event(string title, string description, DateTime date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    // Standard details - Lists the title, description, date, time, and address
    public virtual string GetStandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nDate: {_date.ToShortDateString()}\nTime: {_time}\nAddress: {_address}";
    }

    // Full details - Adds type of event and specific details based on event type
    public virtual string GetFullDetails()
    {
        return GetStandardDetails(); // Base class provides common details
    }

    // Short description - Lists the type of event, title, and the date
    public virtual string GetShortDescription()
    {
        return $"Event Type: {this.GetType().Name}\nTitle: {_title}\nDate: {_date.ToShortDateString()}";
    }
}

// The Lecture class inherits from Event and adds speaker and capacity details
class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    // Constructor to initialize lecture-specific details
    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    // Override full details to include speaker and capacity information
    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nSpeaker: {_speaker}\nCapacity: {_capacity}";
    }
}

// The Reception class inherits from Event and adds an RSVP email address
class Reception : Event
{
    private string _rsvpEmail;

    // Constructor to initialize reception-specific details
    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    // Override full details to include RSVP email information
    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nRSVP Email: {_rsvpEmail}";
    }
}

// The OutdoorGathering class inherits from Event and adds weather forecast details
class OutdoorGathering : Event
{
    private string _weatherForecast;

    // Constructor to initialize outdoor gathering-specific details
    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        _weatherForecast = weatherForecast;
    }

    // Override full details to include weather forecast information
    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nWeather Forecast: {_weatherForecast}";
    }
}

// Main program to test the Event classes and methods
class Program
{
    static void Main()
    {
        // Create address for all events
        Address eventAddress = new Address("123 Park Lane", "Los Angeles", "CA", "USA");

        // Create different types of events
        Event lectureEvent = new Lecture("C# Programming Lecture", "A deep dive into C# programming.", new DateTime(2025, 5, 10), "10:00 AM", eventAddress, "John Doe", 50);
        Event receptionEvent = new Reception("Wedding Reception", "Celebrate the union of Jane and John.", new DateTime(2025, 6, 15), "6:00 PM", eventAddress, "rsvp@wedding.com");
        Event outdoorEvent = new OutdoorGathering("Summer Picnic", "Enjoy an afternoon of games and food.", new DateTime(2025, 7, 20), "1:00 PM", eventAddress, "Sunny with a chance of rain");

        // Display standard details for each event
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorEvent.GetStandardDetails());
        Console.WriteLine();

        // Display full details for each event
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorEvent.GetFullDetails());
        Console.WriteLine();

        // Display short description for each event
        Console.WriteLine(lectureEvent.GetShortDescription());
        Console.WriteLine();
        Console.WriteLine(receptionEvent.GetShortDescription());
        Console.WriteLine();
        Console.WriteLine(outdoorEvent.GetShortDescription());
    }
}
