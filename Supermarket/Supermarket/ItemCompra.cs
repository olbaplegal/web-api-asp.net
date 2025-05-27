using System;

namespace Supermercado
{
    /// <summary>
    /// Classe que representa um item de compra do supermercado
    /// </summary>
    public class ItemCompra
    {
        // Atributos
        private string Id { get; set; }
        private int Quantidade { get; set; }
        private double PrecoUnitario { get; set; }
        private double Subtotal { get; set; }
        private Produto Produto { get; set; }

        /// <summary>
        /// Construtor da classe ItemCompra
        /// </summary>
        public ItemCompra()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Construtor da classe ItemCompra com parâmetros
        /// </summary>
        /// <param name="produto">Produto a ser comprado</param>
        /// <param name="quantidade">Quantidade do produto</param>
        /// <param name="precoUnitario">Preço unitário do produto</param>
        public ItemCompra(Produto produto, int quantidade, double precoUnitario)
        {
            Id = Guid.NewGuid().ToString();
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            CalcularSubtotal();
        }

        /// <summary>
        /// Calcula o subtotal do item de compra
        /// </summary>
        /// <returns>O valor do subtotal</returns>
        public double CalcularSubtotal()
        {
            Subtotal = Quantidade * PrecoUnitario;
            return Subtotal;
        }
    }
}
