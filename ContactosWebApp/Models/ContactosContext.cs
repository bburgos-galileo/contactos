using Microsoft.EntityFrameworkCore;

namespace ContactosWebApp.Models
{
    public class ContactosContext : DbContext
    {
        public DbSet<Contacto> Contactos { get; set; }

        public ContactosContext(DbContextOptions<ContactosContext> options) : base(options)
        {
        }

    }
}
