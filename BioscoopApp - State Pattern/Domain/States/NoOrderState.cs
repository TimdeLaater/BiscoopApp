using Domain.Models;
using DomainServices.Domain.States;
using DomainServices.Interfaces;

namespace BioscoopApp___State_Pattern.Domain.States;

public class NoOrderState : IState<OrderStatePattern>

{
    private OrderStatePattern Order;
    public NoOrderState(OrderStatePattern order)
    {
        Order = order;
    }

    public void CancelOrder()
    {
        Console.WriteLine("There is no order placed. Canceling is not possible");
    }

    public bool HasTicketsLeft()
    {
        return Order.MovieTicket?.MovieScreening.TicketsOrdered.Count > 0;
    }

    public void PayOrder()
    {
        Console.WriteLine("There is no order placed. Please place a order for futher steps.");
    }

    public void ReminderPayOrder()
    {
        Console.WriteLine("There is no order placed. Please place a order for futher steps.");
    }

    public void SendTicketsToCustumer()
    {
        Console.WriteLine("There is no order placed. Please place a order for futher steps.");
    }

    public void SubmitOrder()
    {
        Order.AddSeatReservation();
        Order.TransitionTo(new OrderReservedState(Order));
        Console.WriteLine("Order Submitted");
    }

    public void UpdateOrder(OrderStatePattern order)
    {
        Console.WriteLine("There is no order placed. Please place a order for futher steps.");
    }
    public void SetContext(OrderStatePattern order)
    {
        Order = order;
    }
}