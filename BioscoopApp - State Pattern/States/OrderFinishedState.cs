using BioscoopApp___State_Pattern.Domain;
using DomainServices.Interfaces;

namespace BioscoopApp___State_Pattern.States;

public class OrderFinishedState : IState<OrderStatePattern>
{
    private OrderStatePattern _order;

    public OrderFinishedState(OrderStatePattern order)
    {
        _order = order;
    }

    public void CancelOrder()
    {
        Console.WriteLine("The order is already payed, canceling is not a option.");
    }

    public bool HasTicketsLeft()
    {
        return _order.MovieTicket?.MovieScreening.TicketsOrdered.Count > 0;
    }

    public void PayOrder()
    {
        Console.WriteLine("The order is already payed, enjoy the movie!");
    }

    public void ReminderPayOrder()
    {
        Console.WriteLine("The order is already payed, enjoy the movie!");
    }

    public void SendTicketsToCostumer()
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
        _order = order;
    }
}

