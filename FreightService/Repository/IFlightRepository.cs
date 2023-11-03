// See https://aka.ms/new-console-template for more information
using FreightService;

namespace FreightService.Repository
{
    public interface IFlightRepository
    {
        List<Flight> GetFlights();
        void AddFlight(Flight flight);
        void RemoveFlight(Flight flight);
        void UpdateFlight(Flight flight);
        void DeleteFlight(Flight flight);
        void DeleteAll(Flight flight);
    }
}