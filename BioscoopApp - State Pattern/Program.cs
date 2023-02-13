// See https://aka.ms/new-console-template for more information
using BioscoopApp___State_Pattern.Domain;
using Domain.Models;

var movie = new Movie("Revenge of the Sith");
var movieScreening = new MovieScreening(movie, DateTime.Now, 10, 200);
var movieTicket = new MovieTicket(movieScreening, 1, 1, false);
var order = new OrderStatePattern(8, false, movieTicket);


// No Order State
    // Order not placed yet, should display log.
    order.UpdateOrder(new OrderStatePattern(0, false, movieTicket));
    order.PayOrder();
    order.CancelOrder();
    order.ReminderPayOrder();
    order.SendTicketsToCostumer();
    // Should proceed to next state: Order Reserved
    order.SubmitOrder();

// Order Reserved State
    // Changes or canceling should be allowed on this state
    order.UpdateOrder(new OrderStatePattern(0, false, movieTicket));
    order.SubmitOrder();
    // Enters order canceled  state
    order.CancelOrder();

// Order Canceled State
// No function should be allowed because order no longer exists
    order.UpdateOrder(new OrderStatePattern(0, false, movieTicket));
    order.PayOrder();
    order.CancelOrder();
    order.ReminderPayOrder();
    order.SendTicketsToCostumer();
    order.SubmitOrder();

// Order Reserved State
// New order because previous was canceled :P
    order = new OrderStatePattern(0, false, movieTicket);
    // Advance to Order Reserved 
    order.SubmitOrder();
    // As the order is not payed yet, those function should not be allowed
    order.SendTicketsToCostumer();
    // If the day of today is < 24h of the screening time, should send a reminder to customer 
    order.ReminderPayOrder();
    // Enters Order Finished State
    order.PayOrder();

// Order Finished State
// No actions remain to the stages, so all functions will log a message of conclusion
    order.UpdateOrder(new OrderStatePattern(0, false, movieTicket));
    order.PayOrder();
    order.CancelOrder();
    order.ReminderPayOrder();
    order.SendTicketsToCostumer();
    order.SubmitOrder();
