namespace Domain.Models;

public class MovieScreening
{
    public List<MovieTicket> TicketsOrdered { get; }
    public DateTime DateAndTime { get; }
    private double PricePerSeat { get; }
    private Movie Movie { get; }
    public int MaxSeats { get; }
    public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat, int maxSeats)
    {
        Movie = movie;
        DateAndTime = dateAndTime;
        PricePerSeat = pricePerSeat;
        TicketsOrdered = new List<MovieTicket>();
        MaxSeats = maxSeats;
    }
    public double GetPricePerSeat()
    {
        return PricePerSeat;
    }

    public override string ToString()
    {
        return $"{Movie.Title}, screening at: {DateAndTime}. Get Your tickets today for €{PricePerSeat}";
    }
}