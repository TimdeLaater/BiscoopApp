namespace BiscoopApp.Domain
{
    public class MovieScreening
    {
        public List<MovieTicket> TicketsOrdered { get; set; }
        public DateTime DateAndTime { get; set; }
        private double PricePerSeat { get; }
        private Movie Movie { get; }
        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            Movie = movie;
            DateAndTime = dateAndTime;
            PricePerSeat = pricePerSeat;
            TicketsOrdered = new List<MovieTicket>();
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
}
