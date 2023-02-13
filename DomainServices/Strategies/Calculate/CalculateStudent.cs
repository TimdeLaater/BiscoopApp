using Domain.Models;
using DomainServices.Interfaces;

namespace Domain.Strategies.Calculate;

public class CalculateStudent : ICalculate
{
    private int PremiumExtra { get; }
    private MovieTicket MovieTicket { get; }
    public CalculateStudent(MovieTicket movieTicket)
    {
        MovieTicket = movieTicket;
        if (MovieTicket.IsPremium)
            PremiumExtra = 2;
    }
    public double Calculate(int orderNr)
    {
        var count = 0;
        while (orderNr % 2 == 0 && orderNr != 0)
        {
            count++;
            orderNr -= 2;
        }
        return (count + orderNr) * (MovieTicket.GetPrice() + PremiumExtra);
    }
}