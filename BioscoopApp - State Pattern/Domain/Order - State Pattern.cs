using BioscoopApp___State_Pattern.States;
using Domain.Models;
using Domain.Strategies.Calculate;
using Domain.Strategies.Export;
using DomainServices.Interfaces;

namespace BioscoopApp___State_Pattern.Domain;

public class OrderStatePattern
{
    public IState<OrderStatePattern> State { get; set; }
    private int Id { get; set; }
    private int OrderNr { get; }
    public bool Payed { get; set; } = false;
    private bool IsStudentOrder { get; }
    public MovieTicket? MovieTicket { get; set; }
    private ICalculate? Calculate { get; set; }
    private IExport? Export { get; set; }
    public OrderStatePattern(int orderNr, bool isStudentOrder, MovieTicket movieTicket)
    {
        MovieTicket = movieTicket;

        if (IsStudentOrder)
            Calculate = new CalculateStudent(MovieTicket);
        else
            Calculate = new CalculateNonStudent(MovieTicket);

        OrderNr = orderNr;
        IsStudentOrder = isStudentOrder;

        if (MovieTicket.MovieScreening.MaxSeats > MovieTicket.MovieScreening.TicketsOrdered.Count)
            State = new NoOrderState(this);
        else
            State = new NoTicketsLeftState(this);
    }
    public void TransitionTo(IState<OrderStatePattern> state)
    {
        Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
        State = state;
        State.SetContext(this);
    }
    public void CancelOrder()
    {
        State.CancelOrder();
    }

    public void PayOrder()
    {
        State.PayOrder();
    }
    public bool HasTicketsLeft()
    {
        return State.HasTicketsLeft();
    }

    public void ReminderPayOrder()
    {
        State.ReminderPayOrder();
    }

    public void SendTicketsToCostumer()
    {
        State.SendTicketsToCostumer();
    }

    public void SubmitOrder()
    {
        State.SubmitOrder();
    }

    public void UpdateOrder(OrderStatePattern order)
    {
        State.UpdateOrder(order);
    }
    public void AddSeatReservation()
    {
        MovieTicket?.MovieScreening.TicketsOrdered.Add(MovieTicket);
        Id = MovieTicket!.MovieScreening.TicketsOrdered.Count;
    }

    public double CalculatePrice()
    {
        return Calculate!.Calculate(OrderNr);
    }

    public void ExportTicket(TicketExportFormat exportFormat)
    {
        Export = exportFormat switch
        {
            TicketExportFormat.Json => new ExportJson(),
            TicketExportFormat.PlainText => new ExportPlainText(),
            _ => Export
        };

        var data = new List<KeyValuePair<string, dynamic>>
        {
            new("ID", Id),
            new("Aantal", OrderNr),
            new("Prijs", CalculatePrice())
        };
        Export!.Export(data);
    }
}