namespace StoreServices.Api.Book.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using StoreServices.Api.Book.Models;
    using System;

    public class ContextBook : DbContext
    {
        #region Properties
        private readonly IConfiguration _configuration;
        #endregion

        #region Tables
        public virtual DbSet<MaterialLibrary> MaterialLibrary { get; set; }
        #endregion

        #region Builds
        public ContextBook()
        {
        }

        public ContextBook(DbContextOptions<ContextBook> options,
            IConfiguration configuration) : base(options)
        {
            this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ContextBook(DbContextOptions<ContextBook> options) : base(options)
        {
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
