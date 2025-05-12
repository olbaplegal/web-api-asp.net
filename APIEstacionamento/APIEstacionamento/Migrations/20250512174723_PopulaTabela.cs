using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class PopulaTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Carros (Placa, Renavan, Cpf, Marca, Modelo, TipoCombustivel) " +
                   "VALUES ('ABC1234', '12345678901', '11122233344', 'Toyota', 'Corolla', '3')");

            mb.Sql("INSERT INTO Carros (Placa, Renavan, Cpf, Marca, Modelo, TipoCombustivel) " +
                   "VALUES ('XYZ5678', '98765432100', '55566677788', 'Honda', 'Civic', '2')");

            mb.Sql("INSERT INTO Carros (Placa, Renavan, Cpf, Marca, Modelo, TipoCombustivel) " +
                   "VALUES ('DEF4321', '19283746555', '99988877766', 'Chevrolet', 'Onix', '1')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Carros");
        }
    }
}
