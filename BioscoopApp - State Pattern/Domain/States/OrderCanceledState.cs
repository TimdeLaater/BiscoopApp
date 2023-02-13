using Domain.Models;
using DomainServices.Interfaces;

namespace BioscoopApp___State_Pattern.Domain.States;

public class OrderCanceledState: IState<OrderStatePattern>
{
    private OrderStatePattern Order;

    public OrderCanceledState(OrderStatePattern order)
    {
        Order = order;
    }

    public void CancelOrder()
    {
        Console.WriteLine("This order is already canceled.");
    }

    public void PayOrder()
    {
        Console.WriteLine("This order is canceled.");
    }

    public bool HasTicketsLeft()
    {
        return Order.MovieTicket?.MovieScreening.TicketsOrdered.Count > 0;
    }

    public void ReminderPayOrder()
    {
        Console.WriteLine("This order is canceled.");
    }

    public void SendTicketsToCustumer()
    {
        Console.WriteLine("This order is canceled.");
    }

    public void SubmitOrder()
    {
        Console.WriteLine("This order is canceled.");
    }

    public void UpdateOrder(OrderStatePattern order)
    {
        Console.WriteLine("This order is canceled.");
    }
    public void SetContext(OrderStatePattern order)
    {
        Order = order;
    }
}

