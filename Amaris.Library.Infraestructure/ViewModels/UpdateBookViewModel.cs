namespace Amaris.Library.Infraestructure.ViewModels
{
    public class UpdateBookViewModel
    {       
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Loans { get; set; }
        public bool Taken { get; set; }
    }
}
