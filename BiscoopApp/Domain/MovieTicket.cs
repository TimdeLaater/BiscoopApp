namespace BiscoopApp.Domain
{
    public class MovieTicket
    {
        public int RowNr { get; }
        public int SeatNr { get; }
        public bool IsPremium { get; }
        public MovieScreening MovieScreening { get; }

        public MovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremiumReservation)
        {
            MovieScreening = movieScreening;
            RowNr = rowNr;
            SeatNr = seatNr;
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
}
