using System;

namespace Supermercado
{
    public class ItemVenda
    {
        private string Id { get; set; }
        private int Quantidade { get; set; }
        private double PrecoUnitario { get; set; }
        private double Subtotal { get; set; }
        private double DescontoAplicado { get; set; }
        private Produto Produto { get; set; }


        public ItemVenda(Produto produto, int quantidade, double precoUnitario)
        {
            Id = Guid.NewGuid().ToString();
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            DescontoAplicado = 0;
            CalcularSubtotal();
        }

        public ItemVenda(string id, int quantidade, double precoUnitario, double subtotal, double descontoAplicado, Produto produto)
        {
            Id = id;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Subtotal = subtotal;
            DescontoAplicado = descontoAplicado;
            Produto = produto;
        }

        public double CalcularSubtotal()
        {
            Subtotal = (Quantidade * PrecoUnitario) - DescontoAplicado;
            return Subtotal;
        }

        public void AplicarDesconto()
        {
            //10% desconto
            DescontoAplicado = Quantidade * PrecoUnitario * 0.1;
            CalcularSubtotal();
            Console.WriteLine($"Desconto de R$ {DescontoAplicado:F2} aplicado ao item {Produto}");
        }
    }
}
