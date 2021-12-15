namespace StoreServices.Api.Book.Mapper.MaterialLibrary
{
    using AutoMapper;
    using StoreServices.Api.Book.EntityDTO;
    using StoreServices.Api.Book.Models;

    public class MaterialLibraryMap : Profile
    {
        public MaterialLibraryMap()
        {
            CreateMap<MaterialLibrary, MaterialLibraryDto>();
        }
    }
}
