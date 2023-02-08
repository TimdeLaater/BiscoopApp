using BiscoopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BiscoopApp.Domain.Calculate
{
    public class CalculateNonStudent : ICalculate
    {
        private MovieTicket MovieTicket { get; set; }
        public CalculateNonStudent(MovieTicket movieTicket)
        {
            MovieTicket = movieTicket;
        }
        public double Calculate(int OrderNr)
        {
            int premiumExtra = 0;
            if (MovieTicket.IsPremiumTicket())
                premiumExtra = 3;

            if(IsWeekend() && OrderNr >= 6)
                return (OrderNr) * (MovieTicket!.GetPrice() + premiumExtra) * 0.9;
            return (OrderNr) * (MovieTicket!.GetPrice() + premiumExtra);
        }

        public bool IsWeekend()
        {
            var dayScreening = MovieTicket.MovieScreening.DateAndTime;
            return dayScreening.DayOfWeek == DayOfWeek.Sunday || dayScreening.DayOfWeek == DayOfWeek.Saturday || dayScreening.DayOfWeek == DayOfWeek.Friday;
        }
    }
}
