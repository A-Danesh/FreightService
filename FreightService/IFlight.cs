// See https://aka.ms/new-console-template for more information

namespace FreightService
{
    public interface IFlight
    {
        string FlightNumber { get;}
        string Departure { get; }
        string Arrival { get;  }
        int Day { get;  }
        
//        List<Box> Boxes { get; }
        //void AddBox(Box box);
//        bool IsFull { get; }
    }
}