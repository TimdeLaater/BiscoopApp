using BiscoopApp.Interfaces;

namespace BiscoopApp.Domain.Calculate
{
    public class CalculateStudent : ICalculate
    {
        private MovieTicket MovieTicket { get; set; }
        public CalculateStudent(MovieTicket movieTicket)
        {
            MovieTicket = movieTicket;
        }
        public double Calculate(int OrderNr)
        {
            int premiumExtra = 0;
            if (MovieTicket.IsPremiumTicket())
                premiumExtra = 2;

            int Count = 0;
            while (OrderNr % 2 == 0 && OrderNr != 0)
            {
                Count++;
                OrderNr = OrderNr - 2;
            }
            return (Count + OrderNr) * (MovieTicket!.GetPrice() + premiumExtra);
        }
    }
}
