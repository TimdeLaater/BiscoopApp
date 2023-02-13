using Domain.Models;
using DomainServices.Interfaces;

namespace BioscoopApp___State_Pattern.Domain.States;
public class NoTicketsLeftState : IState<OrderStatePattern>
{
    private OrderStatePattern Order;
    public NoTicketsLeftState(OrderStatePattern order)
    {
        Order = order;
    }
    public void CancelOrder()
    {
        Console.WriteLine("No order was placed. Canceling is not possible.");
    }

    public void PayOrder()
    {
        Console.WriteLine("No tickets left.");
    }

    public bool HasTicketsLeft()
    {
        Console.WriteLine("No tickets left.");
        return false;
    }

    public void ReminderPayOrder()
    {
        Console.WriteLine("No tickets left.");
    }

    public void SendTicketsToCustumer()
    {
        Console.WriteLine("No tickets left.");
    }

    public void SubmitOrder()
    {
        Console.WriteLine("No tickets left.");
    }

    public void UpdateOrder(OrderStatePattern order)
    {
        Console.WriteLine("No tickets left.");
    }
    public void SetContext(OrderStatePattern order)
    {
        Order = order;
    }
}

