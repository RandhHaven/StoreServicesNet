namespace StoreServices.Api.ShoppingCart.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using StoreServices.Api.ShoppingCart.Models;
    using System;

    public class ContextShoppingCart : DbContext
    {
        #region Properties
        private readonly IConfiguration _configuration;
        #endregion

        #region Tables
        public virtual DbSet<CartSession> CartSession { get; set; }
        public virtual DbSet<CartSessionDetail> CartSessionDetail { get; set; }
        #endregion

        #region Builds
        public ContextShoppingCart(DbContextOptions<ContextShoppingCart> options,
            IConfiguration configuration) : base(options)
        {
            this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //En caso de que el contexto no este configurado, lo configuramos mediante la cadena de conexion
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AppConnection"));
            }
        }
        #endregion
    }
}