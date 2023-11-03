// See https://aka.ms/new-console-template for more information
using FreightService;
using FreightService.Repository;

public class AirportRepository : IAirportRepository
{
    public List<Airport> GetAirports()
    {
        var airports = new List<Airport>
        {
            new Airport ( "YUL", "Montreal"),
            new Airport ( "YYZ", "Toronto"),
            new Airport ( "YYC", "Calgery"),
            new Airport ( "YVR", "Vancouver")
        };

        return airports;
    }
}