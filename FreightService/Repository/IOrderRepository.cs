// See https://aka.ms/new-console-template for more information
using FreightService;
using System.ComponentModel;

public interface IOrderRepository
{
    Orderdata GetOrders();
    void AddOrder(string orderName, Order order);
    void updateOrder(Orderdata orderdata);
    void deleteOrder(Orderdata orderdata);
    void removeOrder();
}
