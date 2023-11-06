// See https://aka.ms/new-console-template for more information
using FreightService.Dto;
using Newtonsoft.Json;

namespace FreightService.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string filePath;
        private Orderdata OrderData { get; set; } = new();
        public OrderRepository(string filePath)
        {
            this.filePath = filePath;
        }
        public OrderRepository()
        {
        }
        public void Init()
        {
            //THIS METHOD JUST ADDED FOR THE TEST DATA;
            try
            {
                string json = File.ReadAllText(filePath).ToString();
                OrderData = JsonConvert.DeserializeObject<Orderdata>(json);
            }
            catch (Exception e)
            {
                throw new Exception("Check JSON file address .." + e.Message);
            }
        }

        public Orderdata GetOrders()
        {
            return OrderData;
        }

        public Orderdata GetOrders(string flightNumber)
        {
            var orderData = OrderData.Where(x => x.Key == flightNumber).ToDictionary(p => p.Key, p => p.Value);
            return (Orderdata)orderData;
        }

        public void AddOrder(string orderName, Order order)
        {
            OrderData.Add(orderName,order);
        }

        public void removeOrder()
        {
            throw new NotImplementedException();
        }

        public void updateOrder(Orderdata orderdata)
        {
            throw new NotImplementedException();
        }

        public void deleteOrder(Orderdata orderdata)
        {
            throw new NotImplementedException();
        }

    }
}