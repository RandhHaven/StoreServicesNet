namespace StoreServices.Api.Book.Test.BaseTest
{
    using GenFu;
    using System;
    using StoreServices.Api.Book.Models;    
    using System.Collections.Generic;
    using Moq;
    using StoreServices.Api.Book.Persistence;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class BaseBookTest
    {
        public BaseBookTest()
        {
        }

        private IEnumerable<MaterialLibrary> GetDataTest()
        {
            A.Configure<MaterialLibrary>()
                .Fill(x => x.BookTittle).AsFirstName()
                .Fill(x => x.DatePublish.Value).AsFutureDate()
                .Fill(x => x.BookAuthor, () => { return Guid.NewGuid(); })
                .Fill(x => x.MaterialLibraryID, () => { return Guid.NewGuid(); });

            var lista = A.ListOf<MaterialLibrary>(10);
            lista[0].MaterialLibraryID = Guid.Empty;

            return lista;
        }

        protected Mock<ContextBook> CreateContexto()
        {

            var dataPrueba = GetDataTest().AsQueryable();

            var dbSet = new Mock<DbSet<MaterialLibrary>>();
            dbSet.As<IQueryable<MaterialLibrary>>().Setup(x => x.Provider).Returns(dataPrueba.Provider);
            dbSet.As<IQueryable<MaterialLibrary>>().Setup(x => x.Expression).Returns(dataPrueba.Expression);
            dbSet.As<IQueryable<MaterialLibrary>>().Setup(x => x.ElementType).Returns(dataPrueba.ElementType);
            dbSet.As<IQueryable<MaterialLibrary>>().Setup(x => x.GetEnumerator()).Returns(dataPrueba.GetEnumerator());

            dbSet.As<IAsyncEnumerable<MaterialLibrary>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
            .Returns(new AsyncEnumerator<MaterialLibrary>(dataPrueba.GetEnumerator()));


            dbSet.As<IQueryable<MaterialLibrary>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<MaterialLibrary>(dataPrueba.Provider));


            var contexto = new Mock<ContextBook>();
            contexto.Setup(x => x.MaterialLibrary).Returns(dbSet.Object);
            return contexto;
        }

    }
}
