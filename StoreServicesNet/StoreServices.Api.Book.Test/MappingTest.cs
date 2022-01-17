namespace StoreServices.Api.Book.Test
{
    using AutoMapper;
    using StoreServices.Api.Book.EntityDTO;
    using StoreServices.Api.Book.Models;

    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<MaterialLibrary, MaterialLibraryDto>();
        }
    }
}