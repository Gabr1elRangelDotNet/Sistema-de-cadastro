using CrudMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudMvc.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            :base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
