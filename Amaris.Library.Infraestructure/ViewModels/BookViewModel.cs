namespace Amaris.Library.Infraestructure.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Loans { get; set; }
        public bool Taken { get; set; }
    }
}
