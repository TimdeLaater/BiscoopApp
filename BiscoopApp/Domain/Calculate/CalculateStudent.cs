using BioscoopApp.Interfaces;

namespace BioscoopApp.Domain.Calculate;

public class CalculateStudent : ICalculate
{
    private MovieTicket MovieTicket { get; }
    public CalculateStudent(MovieTicket movieTicket)
    {
        MovieTicket = movieTicket;
    }
    public double Calculate(int orderNr)
    {
        var premiumExtra = 0;
        if (MovieTicket.IsPremiumTicket())
            premiumExtra = 2;

        var count = 0;
        while (orderNr % 2 == 0 && orderNr != 0)
        {
            count++;
            orderNr -= 2;
        }
        return (count + orderNr) * (MovieTicket.GetPrice() + premiumExtra);
    }
}