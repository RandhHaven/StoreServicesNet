using StoreServices.Api.Book.Aplication.GenericBase;
using StoreServices.Api.Book.EntityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.Api.Book.Aplication.BookRequest
{
    public class HandlerQueryBook : HandlerQueryData
    {
        public override Task<IEnumerable<GenericDTO>> Handle(CollectionData request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
