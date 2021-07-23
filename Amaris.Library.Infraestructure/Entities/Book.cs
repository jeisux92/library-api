using System;

namespace Amaris.Library.Infraestructure.Entities
{
    public class Book : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Loans { get; set; }
        public bool Taken { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
