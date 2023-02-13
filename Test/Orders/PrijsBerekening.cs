

using Domain.Models;

namespace Test.Orders
{
    public class PrijsBerekening
    {
        private readonly Movie movie = new Movie("Revenge of the Sith");
        [Fact]
        public void Order_student_geen_weekend_minder_dan_6_kaartjes_niet_premium()
        {
            // Arrange
            var aantal = 1;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 2);
            var isPremium = false;
            var isStudentOrder = true;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();
            // Assert
            Assert.Equal(10, sut);
        }

        [Fact]
        public void Order_student_geen_weekend_minder_dan_6_kaartjes_wel_premium()
        {
            // Arrange
            var aantal = 1;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 2);
            var isPremium = true;
            var isStudentOrder = true;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();
            // Assert
            Assert.Equal(12, sut);
        }
        [Fact]
        public void Order_geen_student_geen_weekend_minder_dan_6_kaartjes_wel_premium()
        {
            // Arrange
            var aantal = 1;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 2);
            var isPremium = true;
            var isStudentOrder = false;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();
            // Assert
            Assert.Equal(13, sut);
        }

        [Fact]
        public void Order_geen_student_geen_weekend_minder_dan_6_kaartjes_niet_premium()
        {
            // Arrange
            var aantal = 1;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 2);
            var isPremium = false;
            var isStudentOrder = false;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();
            // Assert
            Assert.Equal(10, sut);
        }

        [Fact]
        public void Order_student_geen_weekend_meer_dan_6_kaartjes_niet_premium()
        {
            // Arrange
            var aantal = 6;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 2);
            var isPremium = false;
            var isStudentOrder = true;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();

            // Assert
            Assert.Equal(30, sut);
        }
        [Fact]
        public void Order_student_geen_weekend_meer_dan_6_kaartjes_wel_premium()
        {
            // Arrange
            var aantal = 6;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 2);
            var isPremium = true;
            var isStudentOrder = true;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();

            // Assert
            Assert.Equal(36, sut);
        }
        [Fact]
        public void Order_geen_student_geen_weekend_meer_dan_6_kaartjes_niet_premium()
        {
            // Arrange
            var aantal = 6;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 2);
            var isPremium = false;
            var isStudentOrder = false;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();

            // Assert
            Assert.Equal(60, sut);
        }
        [Fact]
        public void Order_geen_student_geen_weekend_meer_dan_6_kaartjes_wel_premium()
        {
            // Arrange
            var aantal = 6;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 2);
            var isPremium = true;
            var isStudentOrder = false;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();

            // Assert
            Assert.Equal(78, sut);
        }

        [Fact]
        public void Order_geen_student_wel_weekend_meer_dan_6_kaartjes_niet_premium()
        {
            // Arrange
            var aantal = 6;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 4);
            var isPremium = false;
            var isStudentOrder = false;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();

            // Assert
            Assert.Equal(54, sut);
        }
        [Fact]
        public void Order_student_wel_weekend_minder_6_kaartjes_niet_premium()
        {
            // Arrange
            var aantal = 1;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 4);
            var isPremium = false;
            var isStudentOrder = true;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();

            // Assert
            Assert.Equal(10, sut);
        }
        [Fact]
        public void Order_student_wel_weekend_meer_dan_6_kaartjes_niet_premium()
        {
            // Arrange
            var aantal = 6;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 4);
            var isPremium = false;
            var isStudentOrder = true;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();

            // Assert
            Assert.Equal(30, sut);
        }
        [Fact]
        public void Order_student_wel_weekend_meer_dan_6_kaartjes_wel_premium()
        {
            // Arrange
            var aantal = 6;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 4);
            var isPremium = true;
            var isStudentOrder = true;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();

            // Assert
            Assert.Equal(36, sut);
        }
        [Fact]
        public void Order_geen_student_wel_weekend_meer_dan_6_kaartjes_wel_premium()
        {
            // Arrange
            var aantal = 6;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 4);
            var isPremium = true;
            var isStudentOrder = false;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();

            // Assert
            Assert.Equal(70.2, sut);
        }
        [Fact]
        public void Order_geen_student_wel_weekend_minder_dan_6_kaartjes_niet_premium()
        {
            // Arrange
            var aantal = 1;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 4);
            var isPremium = false;
            var isStudentOrder = false;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();

            // Assert
            Assert.Equal(10, sut);
        }

        [Fact]
        public void Order_geen_student_wel_weekend_minder_dan_6_kaartjes_wel_premium()
        {
            // Arrange
            var movie = new Movie("Revenge of the Sith");
            var aantal = 1;
            var prijs = 10;
            var maxSeats = 200;
            var dateScreening = new DateTime(2023, 2, 4);
            var isPremium = true;
            var isStudentOrder = false;
            var movieScreening = new MovieScreening(movie, dateScreening, prijs, maxSeats);
            var movieTicket = new MovieTicket(movieScreening, 1, 1, isPremium);
            var order = new OrderStrategyPattern(aantal, isStudentOrder, movieTicket);

            // Act
            var sut = order.CalculatePrice();

            // Assert
            Assert.Equal(13, sut);
        }
    }
}