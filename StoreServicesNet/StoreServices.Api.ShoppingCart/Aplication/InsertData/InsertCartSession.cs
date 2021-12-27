namespace StoreServices.Api.ShoppingCart.Aplication.InsertData
{
    using MediatR;
    using StoreServices.Api.ShoppingCart.Models;
    using StoreServices.Api.ShoppingCart.Persistence;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class InsertCartSession
    {
        public class Execute : IRequest
        {
            public DateTime? CreateDate { get; set; }
            public List<String> ProductList { get; set; }
        }
    
        public class Handler : IRequestHandler<Execute>
        {
            public readonly ContextShoppingCart _context;

            public Handler(ContextShoppingCart context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var cartSession = new CartSession
                {
                    CreateDate = request.CreateDate
                };

                _context.CartSession.Add(cartSession);

                var value = await _context.SaveChangesAsync();
                if (value == 0)
                {
                    throw new Exception("Insert Data with errors with Cart Session");
                }
                
                var valueDetail = AddListDetails(request, cartSession);
                
                return Unit.Value;
            }

            private async Task<Unit> AddListDetails(Execute request, CartSession cartSession)
            {
                var id = cartSession.CartSessionID;
                if (!Object.Equals(request.ProductList, null) && request.ProductList.Any())
                {
                    request.ProductList.ForEach(prod =>
                    {
                        var cartSessionDetail = new CartSessionDetail
                        {
                            CreateDate = DateTime.Now,
                            CartSessionID = id ?? 0,
                            ProductSelected = prod
                        };

                        _context.CartSessionDetail.Add(cartSessionDetail);
                    });
                }

                var valueDetail = await _context.SaveChangesAsync();
                if (valueDetail == 0)
                {
                    throw new Exception("Insert Data with errors Cart Session Detail");
                }
                return Unit.Value;
            }

        }
    }
}