// See https://aka.ms/new-console-template for more information

namespace FreightService.Repository
{
    public class FlightOrdersRepository : IFlightOrdersRepository
    {
        private List<FlightOrders> FlightOrders { get; set; } = new();
        public List<FlightOrders> GetFlightOrders()
        {
            return FlightOrders;
        }
        public void AddFlightOrder(FlightOrders flightOrders)
        {
            FlightOrders.Add(flightOrders);

            //flight order should be persist in database.
        }
    }
}
