using BibliotecaAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) //Realiza ciertas configuraciones fuera de la clase y se las envian a travez del constructor
        {
        }

        public DbSet<Autor> Autores { get; set; }
    }
}
