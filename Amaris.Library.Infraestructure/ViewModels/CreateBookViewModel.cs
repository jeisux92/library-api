using System.ComponentModel.DataAnnotations;

namespace Amaris.Library.Infraestructure.ViewModels
{
    public class CreateBookViewModel
    {
        [Required(AllowEmptyStrings =false)]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Author { get; set; }
        public int Year { get; set; }
    }
}
