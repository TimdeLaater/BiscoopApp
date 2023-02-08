namespace BiscoopApp.Domain
{
    public class Movie
    {
        public string Title { get; }

        public Movie(string title)
        {
            Title = title;
        }
        public void AddScreening(MovieScreening screening)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
