using BiscoopApp.Domain.Calculate;
using BiscoopApp.Domain.Export;
using BiscoopApp.Interfaces;

namespace BiscoopApp.Domain;

public class Order
{
    public Order(int orderNr, bool isStudentOrder)
    {
        OrderNr = orderNr;
        IsStudentOrder = isStudentOrder;
    }

    private int Id { get; set; }
    private int OrderNr { get; }
    private bool IsStudentOrder { get; }
    private MovieTicket? Ticket { get; set; }
    private ICalculate? Calculate { get; set; }
    private IExport? Export { get; set; }

    public void AddSeatReservation(MovieTicket ticket)
    {
        Ticket = ticket;
        Ticket.MovieScreening.TicketsOrdered.Add(Ticket);
        Id = Ticket.MovieScreening.TicketsOrdered.Count;
    }

    public double CalculatePrice()
    {
        if (IsStudentOrder)
            Calculate = new CalculateStudent(Ticket!);
        else
            Calculate = new CalculateNonStudent(Ticket!);
        return Calculate.Calculate(OrderNr);
    }

    public void ExportTicket(TicketExportFormat exportFormat)
    {
        Export = exportFormat switch
        {
            TicketExportFormat.JSON => new ExportJson(),
            TicketExportFormat.PLAINTEXT => new ExportPlainText(),
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