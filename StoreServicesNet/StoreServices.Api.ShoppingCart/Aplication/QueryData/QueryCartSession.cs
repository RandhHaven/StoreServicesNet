using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.ShoppingCart.Models;
using StoreServices.Api.ShoppingCart.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.Api.ShoppingCart.Aplication.QueryData
{
    public class QueryCartSession
    {
        public class CartSesionCollection : IRequest<List<CartSessionDetail>>
        {
        }

        public class HandlerData : IRequestHandler<CartSesionCollection, List<CartSessionDetail>>
        {
            public readonly ContextShoppingCart _context;

            public HandlerData(ContextShoppingCart context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<List<CartSessionDetail>> Handle(CartSesionCollection request, CancellationToken cancellationToken)
            {
                var lister = await _context.CartSessionDetail.ToListAsync();
                return lister;
            }
        }
    }
}
