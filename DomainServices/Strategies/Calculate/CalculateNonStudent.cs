using Domain.Models;
using DomainServices.Interfaces;

namespace Domain.Strategies.Calculate;

public class CalculateNonStudent : ICalculate
{
    private int PremiumExtra { get; }
    private MovieTicket MovieTicket { get; }
    public CalculateNonStudent(MovieTicket movieTicket)
    {
        MovieTicket = movieTicket;
        if (MovieTicket.IsPremium)
            PremiumExtra = 3;
    }
    public double Calculate(int orderNr)
    {
        if (IsWeekend() && orderNr >= 6)
            return orderNr * (MovieTicket.GetPrice() + PremiumExtra) * 0.9;
        return orderNr * (MovieTicket.GetPrice() + PremiumExtra);
    }

    public bool IsWeekend()
    {
        var dayScreening = MovieTicket.MovieScreening.DateAndTime;
        return dayScreening.DayOfWeek is DayOfWeek.Sunday or DayOfWeek.Saturday or DayOfWeek.Friday;
    }
}