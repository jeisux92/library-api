using Amaris.Library.Infraestructure.Entities;
using Amaris.Library.Infraestructure.ViewModels;
using AutoMapper;

namespace Amaris.Library.Infraestructure.Mappers
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<Book, BookViewModel>()
                .ForSourceMember(src => src.CreatedOn, opt => opt.DoNotValidate())
                .ReverseMap();

            CreateMap<CreateBookViewModel, Book>();

            CreateMap<UpdateBookViewModel, Book>();
        }
    }
}
