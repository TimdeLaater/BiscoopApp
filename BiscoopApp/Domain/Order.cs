using BiscoopApp.Domain.Calculate;
using BiscoopApp.Domain.Export;
using BiscoopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiscoopApp.Domain
{

    public class Order
    {
        private int Id { get; set; }
        private int OrderNr { get; set; }
        private bool IsStudentOrder { get; set; }
        private MovieTicket Ticket { get; set; }
        private ICalculate Calculate { get; set; }
        private IExport Export { get; set; }

        public Order(int orderNr, bool isStudentOrder)
        {
            OrderNr = orderNr;
            IsStudentOrder = isStudentOrder;
        }
        public void AddSeatReservation(MovieTicket ticket)
        {
            Ticket = ticket;
            Ticket.MovieScreening.TicketsOrdered.Add(Ticket);
        }
        public double CalculatePrice()
        {
            if (IsStudentOrder)
                Calculate = new CalculateStudent(Ticket!);
            else
                Calculate = new CalculateNonStudent(Ticket!);
           return  Calculate.Calculate(OrderNr);
        }

        public void ExportTicket(TicketExportFormat exportFormat)
        {
            switch (exportFormat) {
                case TicketExportFormat.JSON:
                    Export = new ExportJSON();
                    break;
                case TicketExportFormat.PLAINTEXT:
                    Export = new ExportPlainText();
                    break;

            }
            var data = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("ID", Id),
                new KeyValuePair<string, dynamic>("Aantal", OrderNr),
                new KeyValuePair<string, dynamic>("Prijs", CalculatePrice()),
            };
            Export.Export(data);  
        }
    }
}
