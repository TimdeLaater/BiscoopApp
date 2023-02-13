using Domain.Models;
using DomainServices.Interfaces;

namespace BioscoopApp___State_Pattern.Domain.States;

public class OrderFinishedState: IState<OrderStatePattern>
{
    private OrderStatePattern Order;

    public OrderFinishedState(OrderStatePattern order)
    {
        Order = order;
    }

    public void CancelOrder()
    {
        Console.WriteLine("The order is already payed, canceling is not a option.");
    }

    public bool HasTicketsLeft()
    {
        return Order.MovieTicket?.MovieScreening.TicketsOrdered.Count > 0;
    }

    public void PayOrder()
    {
        Console.WriteLine("The order is already payed, enjoy the movie!");
    }

    public void ReminderPayOrder()
    {
        Console.WriteLine("The order is already payed, enjoy the movie!");
    }

    public void SendTicketsToCustumer()
    {
        Console.WriteLine("The tickets will be send to your email, enjoy the movie!");
    }

    public void SubmitOrder()
    {
        Console.WriteLine("The order is already payed, enjoy the movie!");
    }
    public void UpdateOrder(OrderStatePattern order)
    {
        Console.WriteLine("The order is already payed, enjoy the movie!");
    }
    public void SetContext(OrderStatePattern order)
    {
        Order = order;
    }
}

