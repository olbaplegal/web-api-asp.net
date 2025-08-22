using APICatalogo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context;

public class AppDbContext : IdentityDbContext<ApplicationUser>// aplicando a ApplicationUser
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : 
        base(options)
    { }

    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Produto>? Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)//definindo o código para ele executar o construtor da classe base
    {
        base.OnModelCreating(builder);
    }
}
