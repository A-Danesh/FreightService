// See https://aka.ms/new-console-template for more information

using FreightService.Repository;
using System.Security.Cryptography;

namespace FreightService
{
    public class OrderSchedulingService
    {
        private Orderdata OrderData = new();
        private List<Flight> flights = new();
        private List<FlightOrders> FlightOrders = new();
        private readonly IOrderRepository orderRepository;
        private readonly IFlightRepository flightRepository;

        public Orderdata Orderdata
        {
            get { return OrderData; }
        }

        public List<Flight> Flights
        {
            get { return flights; }
        }
        public OrderSchedulingService(
            IOrderRepository orderRepository,
            IFlightRepository flightRepository)
        {
            this.orderRepository = orderRepository;
            this.flightRepository = flightRepository;
        }

        public void LoadFlights()
        {
            flights = flightRepository.GetFlights();
        }

        public void LoadOrders()
        {
            OrderData = orderRepository.GetOrders();
        }

        public List<FlightOrders> AllocateFlightOrders()
        {
            LoadFlights();
            LoadOrders();

            Flight selectedFlight;
            foreach (var order in OrderData)
            {
                selectedFlight = FindAvailableFlight(order.Value.Destination);
                FlightOrders.Add(new FlightOrders() { FlghtNumber = selectedFlight?.FlightNumber, OrderNumber = order.Key });
                if (selectedFlight != null)
                    selectedFlight.AddBox();
            }
            return FlightOrders;
        }

        public List<FlightItinerary> GetFlightItinaries()
        {

            var Itinariries =
                (from flightOrder in FlightOrders
                 join flight in flights on flightOrder.FlghtNumber equals flight.FlightNumber into tmp
                 from item in tmp.DefaultIfEmpty()
                 select new FlightItinerary()
                 {
                     OrderNumber = flightOrder.OrderNumber,
                     FlightNumber = flightOrder?.FlghtNumber,
                     Departure = item?.Departure,
                     Arrival = item?.Arrival,
                     Day = item?.Day
                 }).ToList();

            return Itinariries;

        }
        private Flight? FindAvailableFlight(string destination)
        {
            var selectedFlight = flights
                .Where(flight => !flight.IsFull && flight.Arrival == destination).FirstOrDefault();

            return selectedFlight;
        }

        private List<Flight> FlightCapacity(string destination)
        {
            // to do
            return null;
        }
    }

}