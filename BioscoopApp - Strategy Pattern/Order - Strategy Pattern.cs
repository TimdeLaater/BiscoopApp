using Domain.Strategies.Calculate;
using Domain.Strategies.Export;
using DomainServices.Interfaces;

namespace Domain.Models;

public class OrderStrategyPattern
{
    private int Id { get; set; }
    private int OrderNr { get; }
    public MovieTicket? MovieTicket { get; set; }
    private ICalculate? Calculate { get; set; }
    private IExport? Export { get; set; }
    public OrderStrategyPattern(int orderNr, bool isStudentOrder, MovieTicket movieTicket)
    {
        MovieTicket = movieTicket;

        if (isStudentOrder)
            Calculate = new CalculateStudent(MovieTicket);
        else
            Calculate = new CalculateNonStudent(MovieTicket);

        OrderNr = orderNr;
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