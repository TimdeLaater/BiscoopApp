// See https://aka.ms/new-console-template for more information
using BiscoopApp.Domain;

Console.WriteLine("Hello, World!");
var movie1 = new Movie("Revenge of the Sith");
var movieScreening1 = new MovieScreening(movie1, DateTime.Now, 10);
Movie.AddScreening(movieScreening1);
var order = new Order(8, false);
order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, true));
Console.WriteLine(order.CalculatePrice());
order.ExportTicket(TicketExportFormat.Json);