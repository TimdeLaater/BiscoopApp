using BiscoopApp.Domain;

namespace Test.Orders;

public class PrijsBerekening
{
    [Fact]
    public void Order_student_geen_weekend_minder_dan_6_kaartjes_niet_premium()
    {
        // Arrange
        var movie = new Movie("Revenge of the Sith");
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 2), 10);
        Movie.AddScreening(movieScreening1);
        var order = new Order(1, true);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, false));

        // Act
        var sut = order.CalculatePrice();
        // Assert
        Assert.Equal(10, sut);
    }

    [Fact]
    public void Order_student_geen_weekend_minder_dan_6_kaartjes_wel_premium()
    {
        // Arrange
        var movie = new Movie("Revenge of the Sith");
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 2), 10);
        Movie.AddScreening(movieScreening1);
        var order = new Order(1, true);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, true));

        // Act
        var sut = order.CalculatePrice();
        // Assert
        Assert.Equal(12, sut);
    }
    [Fact]
    public void Order_geen_student_geen_weekend_minder_dan_6_kaartjes_wel_premium()
    {
        // Arrange
        var movie = new Movie("Revenge of the Sith");
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 2), 10);
        Movie.AddScreening(movieScreening1);
        var order = new Order(1, false);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, true));

        // Act
        var sut = order.CalculatePrice();
        // Assert
        Assert.Equal(13, sut);
    }

    [Fact]
    public void Order_geen_student_geen_weekend_minder_dan_6_kaartjes_niet_premium()
    {
        // Arrange
        var movie = new Movie("Revenge of the Sith");
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 2), 10);
        Movie.AddScreening(movieScreening1); 
        var order = new Order(1, false);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, true));

        // Act
        var sut = order.CalculatePrice();
        // Assert
        Assert.Equal(13, sut);
    }

    [Fact]
    public void Order_student_geen_weekend_meer_dan_6_kaartjes_niet_premium()
    {
        // Arrange
        var movie = new Movie("Revenge of the Sith");
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 2), 10);
        Movie.AddScreening(movieScreening1);
        var order = new Order(6, true);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, false));

        // Act
        var sut = order.CalculatePrice();

        // Assert
        Assert.Equal(30, sut);
    }
    [Fact]
    public void Order_student_geen_weekend_meer_dan_6_kaartjes_wel_premium()
    {
        // Arrange
        var movie = new Movie("Revenge of the Sith");
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 2), 10);
        Movie.AddScreening(movieScreening1);
        var order = new Order(6, true);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, true));

        // Act
        var sut = order.CalculatePrice();

        // Assert
        Assert.Equal(36, sut);
    }
    [Fact]
    public void Order_geen_student_geen_weekend_meer_dan_6_kaartjes_niet_premium()
    {
        // Arrange
        var movie = new Movie("Revenge of the Sith");
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 2), 10);
        Movie.AddScreening(movieScreening1);
        var order = new Order(6, false);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, false));

        // Act
        var sut = order.CalculatePrice();

        // Assert
        Assert.Equal(60, sut);
    }
    [Fact]
    public void Order_geen_student_geen_weekend_meer_dan_6_kaartjes_wel_premium()
    {
        // Arrange
        var movie = new Movie("Revenge of the Sith");
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 2), 10);
        Movie.AddScreening(movieScreening1);
        var order = new Order(6, false);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, true));

        // Act
        var sut = order.CalculatePrice();

        // Assert
        Assert.Equal(78, sut);
    }

    [Fact]
    public void Order_geen_student_wel_weekend_meer_dan_6_kaartjes_niet_premium()
    {
        // Arrange
        var movie = new Movie("Revenge of the Sith");
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 4), 10);
        Movie.AddScreening(movieScreening1);
        var order = new Order(6, false);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, false));

        // Act
        var sut = order.CalculatePrice();

        // Assert
        Assert.Equal(54, sut);
    }
    [Fact]
    public void Order_student_wel_weekend_minder_6_kaartjes_niet_premium()
    {
        // Arrange
        var movie = new Movie("Revenge of the Sith");
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 4), 10);
        Movie.AddScreening(movieScreening1);
        var order = new Order(1, false);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, false));

        // Act
        var sut = order.CalculatePrice();

        // Assert
        Assert.Equal(10, sut);
    }
    [Fact]
    public void Order_student_wel_weekend_meer_dan_6_kaartjes_niet_premium()
    {
        // Arrange
        var movie = new Movie("Revenge of the Sith");
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 4), 10);
        Movie.AddScreening(movieScreening1);
        var order = new Order(6, true);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, false));

        // Act
        var sut = order.CalculatePrice();

        // Assert
        Assert.Equal(30, sut);
    }
    [Fact]
    public void Order_student_wel_weekend_meer_dan_6_kaartjes_wel_premium()
    {
        // Arrange
        var movie = new Movie("Revenge of the Sith");
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 4), 10);
        Movie.AddScreening(movieScreening1);
        var order = new Order(6, true);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, true));

        // Act
        var sut = order.CalculatePrice();

        // Assert
        Assert.Equal(36, sut);
    }
    [Fact]
    public void Order_geen_student_wel_weekend_meer_dan_6_kaartjes_wel_premium()
    {
        // Arrange
        var movie = new Movie("Revenge of the Sith");
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 4), 10);
        Movie.AddScreening(movieScreening1);
        var order = new Order(6, false);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, true));

        // Act
        var sut = order.CalculatePrice();

        // Assert
        Assert.Equal(70.2, sut);
    }
    [Fact]
    public void Order_geen_student_wel_weekend_minder_dan_6_kaartjes_niet_premium()
    {
        // Arrange
        var movie = new Movie("Revenge of the Sith");
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 4), 10);
        Movie.AddScreening(movieScreening1);
        var order = new Order(1, false);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, false));

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
        var movieScreening1 = new MovieScreening(movie, new DateTime(2023, 2, 4), 10);
        Movie.AddScreening(movieScreening1);
        var order = new Order(1, false);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, true));

        // Act
        var sut = order.CalculatePrice();

        // Assert
        Assert.Equal(13, sut);
    }
}