namespace StoreServices.Api.Book.Test.BookServiceTest
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using StoreServices.Api.Book.Aplication.BookApplication.Commands.CreateBook;
    using StoreServices.Api.Book.Aplication.BookApplication.Queries.GetBooksAll;
    using StoreServices.Api.Book.Aplication.QueryDataFilter;
    using StoreServices.Api.Book.Models;
    using StoreServices.Api.Book.Persistence;
    using StoreServices.Api.Book.Test.BaseTest;
    using System;
    using System.Linq;
    using Xunit;

    public sealed class BookTest : BaseBookTest
    {
        public BookTest()
        {
        }

        [Fact]
        public async void GetContactById()
        {
            var mockContexto = CreateContexto();

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            var request = new BookDataFilter.BookFilter();
            request.BookID = Guid.Empty;

            var manejador = new BookDataFilter.BookHandler(mockContexto.Object, mapper);

            var book = await manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(book);
            Assert.True(book.MaterialLibraryID == Guid.Empty);
        }

        [Fact]
        public async void GetBooks()
        {
            System.Diagnostics.Debugger.Launch();
            // 1.Emular a la instancia de entity framework core - ContextoLibreria
            // para emular la acciones y eventos de un objeto en un ambiente de unit test 
            //utilizamos objetos de tipo mock

            var mockContexto = CreateContexto();

            // 2 Emular al mapping IMapper

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();
            //3. Instanciar a la clase Manejador y pasarle como parametros los mocks que he creado

            GetBookAllQueryHandler manejador = new GetBookAllQueryHandler(mockContexto.Object, mapper);

            GetBookAllQuery request = new GetBookAllQuery();

            var lista = await manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.True(lista.Any());
        }

        [Fact]
        public async void SaveContacts()
        {
            System.Diagnostics.Debugger.Launch();
            var options = new DbContextOptionsBuilder<ContextBook>()
                .UseInMemoryDatabase(databaseName: "BookDataBase")
                .Options;

            var contexto = new ContextBook(options);

            var request = new CreateBookCommand();
            request.BookTittle = "Microservice Book";
            request.BookAuthor = Guid.Empty;
            request.DatePublish = DateTime.Now;

            var manejador = new CreateBookCommandHandler(contexto);

            var libro = await manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.True(libro != null);
        }
    }
}
