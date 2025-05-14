using APIEstacionamento.Models;
using Microsoft.EntityFrameworkCore;

namespace APIEstacionamento.Context;

public class APIEstacionamentoContext : DbContext
{
    public APIEstacionamentoContext(DbContextOptions<APIEstacionamentoContext> options) : base(options)
    {
    }

    public DbSet<Carro> Carros { get; set; } // ajeitar o context depois
}
