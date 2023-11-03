// See https://aka.ms/new-console-template for more information

using FreightService;
using FreightService.Repository;


var flightsRepo = new FlightRepository();
    flightsRepo.Init();  //JUST FOR LOAD SAMPLE DATA

var ordersRepo = new OrderRepository(@"C:\Users\Aradm\source\repos\FreightService\FreightService\coding-assigment-orders.json");
ordersRepo.Init();   //JUST FOR LOAD SAMPLE DATA

var orderSchedulingService = new OrderSchedulingService(ordersRepo, flightsRepo);
orderSchedulingService.AllocateFlightOrders();

Console.WriteLine("User Story 1 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

ShowFlightSchedule(flightsRepo);

Console.WriteLine("User Story 2 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

ShowFlightItineraries(orderSchedulingService.GetFlightItinaries());

Console.ReadLine();


static void ShowFlightSchedule(FlightRepository flightsRepo)
{
    Console.WriteLine("Flight Schedule:");
    foreach (var flight in flightsRepo.GetFlights())
    {
        Console.WriteLine($"Flight: {flight.FlightNumber}, Departure: {flight.Departure}, Arrival: {flight.Arrival}, day: {flight.Day}");
    }
    Console.WriteLine();
}
static void ShowFlightItineraries(List<FlightItinerary> x)
{
    foreach (var item in x)
    {
        if (item.FlightNumber == null)
        {
            Console.WriteLine($"order: {item.OrderNumber}, flightNumber: {(item.FlightNumber ?? "Not Scheduled")}");
        }
        else
            Console.WriteLine($"order: {item.OrderNumber}" +
                $", flightNumber: {item.FlightNumber}" +
                $", departure: {item.Departure}" +
                $", arrival: {item.Arrival}" +
                $", day: {item.Day}"
                );
    }
}