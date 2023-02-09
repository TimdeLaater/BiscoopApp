using BioscoopApp.Domain;
using BioscoopApp.Interfaces;

namespace BioscoopApp.Domain.Calculate;

public class CalculateNonStudent : ICalculate
{
    private MovieTicket MovieTicket { get; }
    public CalculateNonStudent(MovieTicket movieTicket)
    {
        MovieTicket = movieTicket;
    }
    public double Calculate(int orderNr)
    {
        var premiumExtra = 0;
        if (MovieTicket.IsPremiumTicket())
            premiumExtra = 3;
        if (IsWeekend() && orderNr >= 6)
            return orderNr * (MovieTicket.GetPrice() + premiumExtra) * 0.9;
        return orderNr * (MovieTicket.GetPrice() + premiumExtra);
    }

    public bool IsWeekend()
    {
        var dayScreening = MovieTicket.MovieScreening.DateAndTime;
        return dayScreening.DayOfWeek is DayOfWeek.Sunday or DayOfWeek.Saturday or DayOfWeek.Friday;
    }
}