// See https://aka.ms/new-console-template for more information

using FreightService.Dto;

namespace FreightService.Repository
{
    public interface IFlightOrdersRepository
    {
        void AddFlightOrder(FlightOrders flightOrders);
        List<FlightOrders> GetFlightOrders();
    }
}