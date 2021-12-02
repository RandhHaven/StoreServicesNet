namespace StoreServices.Api.Author.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using StoreServices.Api.Author.Models;

    public class ContextAuthor : DbContext
    {
        #region Properties
        private readonly IConfiguration _configuration;
        #endregion

        #region Tables
        public virtual DbSet<AcademicDegree> AcademicDegree { get; set; }
        public virtual DbSet<BookAuthor> BookAuthor { get; set; }
        #endregion

        #region Builds
        public ContextAuthor(DbContextOptions<ContextAuthor> options,
            IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
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
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("AppConnection"));
            }
        }
        #endregion
    }
}
