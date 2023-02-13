using BioscoopApp___State_Pattern.Domain;
using DomainServices.Interfaces;

namespace BioscoopApp___State_Pattern.States;

public class OrderReservedState : IState<OrderStatePattern>
{
    private OrderStatePattern Order;

    public OrderReservedState(OrderStatePattern order)
    {
        Order = order;
    }

    public void CancelOrder()
    {
        Order.TransitionTo(new OrderCanceledState(Order));
        Console.WriteLine("Order canceled.");
    }

    public void PayOrder()
    {
        Order.Payed = true;
        Order.TransitionTo(new OrderFinishedState(Order));
        Console.WriteLine("Order payed! Enjoy the movie!");
    }

    public bool HasTicketsLeft()
    {
        return Order.MovieTicket?.MovieScreening.TicketsOrdered.Count > 0;
    }

    public void ReminderPayOrder()
    {
        var dateToday = DateTime.Now;
        var difference = dateToday - Order.MovieTicket?.MovieScreening.DateAndTime;
        if (difference!.Value.TotalHours <= 24)
            Console.WriteLine("Please pay your order or else it will be canceled");
    }

    public void SendTicketsToCostumer()
    {
        Console.WriteLine("Order has not been payed yet.");
    }

    public void SubmitOrder()
    {
        Console.WriteLine("Order already submitted. Waiting for the payment of the order.");
    }

    public void UpdateOrder(OrderStatePattern order)
    {
        Order.TransitionTo(new NoOrderState(order));
        Console.WriteLine("Order updated!");
    }

    public void SetContext(OrderStatePattern order)
    {
        order.State = Order.State;
        Order = order;
    }
}
