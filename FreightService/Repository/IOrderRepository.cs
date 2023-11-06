// See https://aka.ms/new-console-template for more information
using FreightService.Dto;
using System.ComponentModel;

public interface IOrderRepository
{
    Orderdata GetOrders();
    Orderdata GetOrders(string flightNumber);
    void AddOrder(string orderName, Order order);
    void updateOrder(Orderdata orderdata);
    void deleteOrder(Orderdata orderdata);
    void removeOrder();
}
