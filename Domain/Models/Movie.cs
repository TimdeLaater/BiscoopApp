namespace Domain.Models;

public class Movie
{
    public string Title { get; }

    public Movie(string title)
    {
        Title = title;
    }
    public static void AddScreening(MovieScreening screening)
    {
        if (screening == null) throw new ArgumentNullException(nameof(screening));
    }

    public override string ToString()
    {
        return Title;
    }
}