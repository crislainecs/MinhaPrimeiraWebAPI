using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraWebAPI.Entities;

namespace MinhaPrimeiraWebAPI.Data
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos {get; set;}

         
        
    }
}