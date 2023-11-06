// See https://aka.ms/new-console-template for more information

namespace FreightService.Dto
{
    public class Flight : IFlight
    {
        public string FlightNumber { get; private set; }
        public string Departure { get; private set; }
        public string Arrival { get; private set; }
        public int Day { get; private set; }
        public int MaxBoxCapacity { get; set; }
        public int BoxCapacity { get; set; }


        public Flight(string flightNumber,
                      string departure,
                      string arrival,
                      int day,
                      int maxBoxCapacity)
        {
            FlightNumber = flightNumber;
            Departure = departure;
            Arrival = arrival;
            Day = day;
            MaxBoxCapacity = maxBoxCapacity;
            BoxCapacity = maxBoxCapacity;
        }

        public void AddBox()
        {

            if (BoxCapacity > 0)
            {
                BoxCapacity--;
            }
        }
        public bool IsFull => BoxCapacity == 0;
    }
}