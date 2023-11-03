// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreightService.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private List<Flight>? Flights { get; set; } = new();

        public void AddFlight(Flight flight)
        {
            Flights.Add(flight);
        }

        public void DeleteAll(Flight flight)
        {
            throw new NotImplementedException();
        }

        public void DeleteFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public List<Flight> GetFlights()
        {
            return Flights;
        }
        public void Init()
        {
            //JUST FOR LOAD SAMPLE DATA

            var f = new List<Flight>()
                {
            new Flight("1", "YUL", "YYZ", 1, 20),
            new Flight("2", "YUL", "YYC", 1, 20),
            new Flight("3", "YUL", "YVR", 1, 20),
            new Flight("4", "YUL", "YYZ", 2, 20),
            new Flight("5", "YUL", "YYC", 2, 20),
            new Flight("6", "YUL", "YVR", 2, 20),
        };

            Flights.AddRange(f);
        }

        public void RemoveFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public void UpdateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
