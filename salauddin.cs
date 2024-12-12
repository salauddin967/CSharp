using System;
using System.Linq;

class User{
    public string UserName {get; set;}
    public string Email {get; set;}
    private string password; 
    public string Password{
        get{return password;}
        set{password = value;}
    }

    // default constructor
    public User(){
        UserName  = "Default";
        Email     = "unknown@gmail.com";
        Password  = "12345678";
    }

    // constructor overloading to register an user
    public User(string Name, string Mail, string Lock){
        UserName  = Name;
        Email     = Mail;
        Password  = Lock;
    }

    // copy constructor for deep copy userinfo
    public User(User other){
        UserName  = other.UserName;
        Email     = other.Email;
        Password  = other.Password;
    }

    // virtual method to display User Information
    public virtual void UserInfo(){
        Console.WriteLine("****************************");
        Console.WriteLine("--- USER INFO ---");
        Console.WriteLine($"UserName : {UserName}");
        Console.WriteLine($"Email    : {Email}");
        Console.WriteLine($"Password : {Password}");
        Console.WriteLine("******************************\n");
    }

    // method to delete user details
    public void DeleteUser(){
        UserName  = "";
        Email     = "";
        Password  = "";
        Console.WriteLine("UserInfo Deleted Successfully.\n");
    }

}

class Event{
    public string EventName {get; set;}
    public string EventDate {get; set;}
    public string EventPlace {get; set;}

    // static variable to track number of Events 
    public static int Eventcnt = 0;

    // constructor as well as adding an event
    public Event(string name, string date, string place){
        EventName  = name;
        EventDate  = date;
        EventPlace = place;
        Eventcnt++;
    }
    
    // updating event (method)
    public void UpdateEvent(string name){
        EventName = name;
    }

    // method overloading 1
    public void UpdateEvent(string date, string place){
        EventDate  = date;
        EventPlace = place;
    }

    // method overloading 2
    public void UpdateEvent(string name, string date, string place){
        EventName  = name;
        EventDate  = date;
        EventPlace = place;
    }

    // method to display Event Details
    public void EventInfo(){
        Console.WriteLine("******************************");
        Console.WriteLine("--- Event Details ---");
        Console.WriteLine($"Event   : {EventName}");
        Console.WriteLine($"Place   : {EventPlace}");
        Console.WriteLine($"Date    : {EventDate}");
        Console.WriteLine("********************************\n");
    }
    
    // static method to display Number of Events
    public static void ShowEventCnt(){
        Console.WriteLine($"Total Events : {Eventcnt}\n");
    }

    // static method for removing an event
    public static void RemoveEvent(){
        Eventcnt--;
        Console.WriteLine($"One Event is removed.");
    }

}

class Ticket{
    public string eventName {get; set;}
    public string ticketID {get; set;}
    public int seatnumber {get; set;}
    public double price {get; set;}

    // constructor for Ticket class
    public Ticket(string EventName, string TicketId, int SeatNumber, double Price){
        eventName  = EventName;
        ticketID   = TicketId;
        seatnumber = SeatNumber;
        price      = Price;
    }

    // operator overloading
    public static double operator+ (Ticket tc1, Ticket tc2){
        return tc1.price + tc2.price;
    }

    // method to display Ticket Details
    public void TicketInfo(){
        Console.WriteLine("******************************");
        Console.WriteLine(">> >> >> Ticket Details << << <<");
        Console.WriteLine($"Event Name  : {eventName}");
        Console.WriteLine($"Ticket ID   : {ticketID}");
        Console.WriteLine($"Seat Number : {seatnumber}");
        Console.WriteLine($"Price       : ${price}");
        Console.WriteLine("******************************");
    }

    // method to return ticket price
    public double Cost(){
        return price;
    }

}

// abstract class
public abstract class TicketManagement{
    public abstract void BookTicket(string EventName, string TicketId, int SeatNumber, double Price);
    public abstract void CancelBooking(int SeatNumber);
}

// interface
public interface FindEvent{
    void SearchEvent(string Eventname);
}

// inheritance
class Admin : TicketManagement, FindEvent{
    
    // overriding for booking of a ticket
    public override void BookTicket(string EventName, string TicketId, int SeatNumber, double Price){
        Ticket user1 = new Ticket(EventName, TicketId, SeatNumber, Price);
        Console.WriteLine("Congrats👍 Ticket Booked Successfully.\n");
        user1.TicketInfo();
        TicketStats.Stats(Price); // tracking ticket sold and revenue
        TicketStats.StatsInfo(user1); // generating invoice 
    }
    
    // overriding for cancelling a booked ticket
    public override void CancelBooking(int SeatNumber){
        if(SeatNumber <= 0){
            Console.WriteLine("Invalid Seat Number.\n");
            return;
        }
        Console.WriteLine($"Ticket for Seat {SeatNumber} has been canceled.");  
    }

    // searching for an event 
    public void SearchEvent(string Eventname){
        string[] events = {"MMA", "BeatBoxing", "Art Exhibition", "Music Fest", "AnimeCon"};

        if(events.Contains(Eventname)){
            Console.WriteLine("Yes, Found the Event.");
        }
        else{
            Console.WriteLine("Sorry, The Event is not on the list.\n");
        }
    }

}

// static class for ticket sold and total revenue statistics
static class TicketStats{
    // every member inside this class is static
    public static int totalTicketSold = 0;
    public static double totalRevenue = 0.00;

    // method to count total ticekt sold and total revenue
    public static void Stats(double price){
        totalTicketSold++;
        totalRevenue += price;
    }

    // method to generate an Invoice
    public static void StatsInfo(Ticket ticket){
        double totalCost = ticket.Cost();

        Console.WriteLine($"//******************************");
        Console.WriteLine("----------- INVOICE ------------");
        ticket.TicketInfo();
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Total Ticket Sold : {totalTicketSold}");
        Console.WriteLine($"Total Cost        : ${totalCost}");
        Console.WriteLine($"Total Revenue     : ${totalRevenue}");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("THANK YOU FOR YOUR PURCHASE 😊");
        Console.WriteLine($"******************************//\n");
    }

}

class OnlineTicketSystem{
    public static void Main(string[] args){

        // Usage of User Class
        User user1 = new User("Sheikh Raihan", "Bond777@gmail.com", "passKoi:(");
        user1.UserInfo();

        // updating user info
        user1.UserName = "Salauddin";
        user1.Password = "passNai:)";
        user1.UserInfo();

        // using deep copy 
        User user2 = new User(user1);
        user2.UserInfo();

        // deleting an user
        user1.DeleteUser();

        // Usuage of Event Class
        Event event1 = new Event("Art Exhibition", "12-02-2025", "Grand Egyptian Museum");
        Event event2 = new Event("AnimeCon", "06-01-2025", "Odaiba Japan");

        // displaying event details
        event1.EventInfo();
        event2.EventInfo();

        // updating an event 
        event1.UpdateEvent("Music Fest", "12-12-2024", "Vienna Austria");
        event1.EventInfo();

        // removing an event & showing total event count
        Event.RemoveEvent();
        Event.ShowEventCnt();

        // Usuage of Ticket Class
        Ticket ticket1 = new Ticket("MMA", "TICK001", 10, 49.99);
        Ticket ticket2 = new Ticket("BeatBoxing", "TICK002", 9, 19.99);

        // showing ticket info
        ticket1.TicketInfo();
        ticket2.TicketInfo();

        // summing up two tickets using operator overloading
        double value = ticket1 + ticket2;
        Console.WriteLine($"Total cost for 2 tickets : ${value}");

        // Usuage of Admin Class
        Admin Charlie = new Admin();
        Charlie.BookTicket("AnimeCon", "TICK007", 46, 99.99); // booking a ticket

        // cancelling a booked ticket
        Charlie.CancelBooking(46);

        // searching for an event
        Charlie.SearchEvent("Art Exhibition");
        Charlie.SearchEvent("Football Match");

        // Report generation & overall Payment Statistics
        TicketStats.StatsInfo(ticket1);
        TicketStats.StatsInfo(ticket2);

    }
}
