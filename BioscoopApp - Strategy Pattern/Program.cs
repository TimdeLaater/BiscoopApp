// See https://aka.ms/new-console-template for more information
using Domain.Models;

var movie = new Movie("Revenge of the Sith");
var movieScreening = new MovieScreening(movie, DateTime.Now, 10, 200);
var movieTicket = new MovieTicket(movieScreening, 1, 1, false);
var order = new OrderStrategyPattern(8, false, movieTicket);
Console.WriteLine(order.CalculatePrice());
order.ExportTicket(TicketExportFormat.Json);