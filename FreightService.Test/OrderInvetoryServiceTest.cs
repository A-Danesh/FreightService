using FreightService;
using FreightService.Dto;
using FreightService.Model;
using FreightService.Repository;

namespace FreightService.Test
{
    [TestClass]
    public class OrderInvetoryServiceTest
    {
         [TestMethod]
        public void Orders_shouldNotAcceptOrderMoreThanItsCapacity()
        {
            //Initial flight repo with one flight
            var FRepo = new FlightRepository();
            FRepo.AddFlight(new Flight("1", "DEP1", "ARR1", 1, 2));

            //Initial order repo with 3 orders related to the below flight destination
            var ORepo = new OrderRepository();
            ORepo.AddOrder("1", new Order() { Destination = "ARR1" });
            ORepo.AddOrder("2", new Order() { Destination = "ARR1" });
            ORepo.AddOrder("3", new Order() { Destination = "ARR1" });

            //Allocate each order to flight based order list
            var OSS = new OrderSchedulingService(ORepo, FRepo);
            OSS.AllocateFlightOrders();
            var itinerary = OSS.GetFlightItinaries().FirstOrDefault(x=>x.OrderNumber == "3");
            var AssertionFlight = FRepo.GetFlights().FirstOrDefault(x => x.Arrival == "ARR1");

            Assert.AreEqual(itinerary.FlightNumber, null);
            Assert.AreEqual(AssertionFlight.BoxCapacity, 0);
        }

        [TestMethod]
        public void Orders_IfAnOrderHasNotYetBeenScheduled_FlightInfoShouldBeNull()
        {
            var FRepo = new FlightRepository();
            FRepo.AddFlight(new Flight("1","DEP1","ARR1",1,3));
            
            var ORepo = new OrderRepository();
            ORepo.AddOrder("1", new Order() { Destination = "ARR2" });
            
            var OSS = new OrderSchedulingService(ORepo,FRepo);                        
            OSS.AllocateFlightOrders();            
            var itinerary = OSS.GetFlightItinaries().FirstOrDefault();

            Assert.AreEqual(itinerary.FlightNumber, null);
        }

        [TestMethod]
        public void Orders_IfAnOrderHasBeenScheduled_FlightInfoShouldBeReturned()
        {
            var FRepo = new FlightRepository();
            FRepo.AddFlight(new Flight("1", "DEP1", "ARR1", 1, 3));

            var ORepo = new OrderRepository();
            ORepo.AddOrder("1", new Order() { Destination = "ARR1" });

            var OSS = new OrderSchedulingService(ORepo, FRepo);
            OSS.AllocateFlightOrders();
            var itinerary = OSS.GetFlightItinaries().FirstOrDefault();

            Assert.AreEqual(itinerary.FlightNumber, "1");
        }

        [TestMethod]
        public void Flight_FlightCapacityshouldBeDeducted_ByAddingAnOrder() {

            var FRepo = new FlightRepository();
            var flight = new Flight("1", "DEP1", "ARR1", 1, 3);
            FRepo.AddFlight(flight);

            var ORepo = new OrderRepository();
            ORepo.AddOrder("1", new Order() { Destination = "ARR1" });


            var OSS = new OrderSchedulingService(ORepo, FRepo);
            OSS.AllocateFlightOrders();

            Assert.IsTrue(flight.BoxCapacity==2,"Order Allocation does not work correctly");
        }
    }

}