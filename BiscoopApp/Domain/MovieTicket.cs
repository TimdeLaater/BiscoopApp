namespace BiscoopApp.Domain;

public class MovieTicket
{
    public bool IsPremium { get; }
    public MovieScreening MovieScreening { get; }

    public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation)
    {
        MovieScreening = movieScreening;
        IsPremium = isPremiumReservation;
    }
    public bool IsPremiumTicket()
    {
        return IsPremium;
    }
    public double GetPrice()
    {
        return MovieScreening.GetPricePerSeat();
    }
}