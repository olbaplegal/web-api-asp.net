using System;
using System.Collections.Generic;

namespace Supermercado
{
    /// <summary>
    /// Classe que representa uma compra feita pelo supermercado a um fornecedor
    /// </summary>
    public class Compra
    {
        // Atributos
        private string Id { get; set; }
        private DateTime Data { get; set; }
        private double ValorTotal { get; set; }
        private string Status { get; set; }
        private DateTime PrazoEntrega { get; set; }
        private Fornecedor Fornecedor { get; set; }
        private List<ItemCompra> Itens { get; set; }

        /// <summary>
        /// Construtor da classe Compra
        /// </summary>
        public Compra()
        {
            Id = Guid.NewGuid().ToString();
            Data = DateTime.Now;
            Itens = new List<ItemCompra>();
            Status = "Em andamento";
        }

        /// <summary>
        /// Adiciona um item à compra
        /// </summary>
        public void AdicionarItem()
        {
            // Implementação da adição de item
            Console.WriteLine("Item adicionado à compra!");
            CalcularValorTotal();
        }

        /// <summary>
        /// Remove um item da compra
        /// </summary>
        public void RemoverItem()
        {
            // Implementação da remoção de item
            Console.WriteLine("Item removido da compra!");
            CalcularValorTotal();
        }

        /// <summary>
        /// Finaliza a compra
        /// </summary>
        public void FinalizarCompra()
        {
            Status = "Finalizada";
            Console.WriteLine($"Compra {Id} finalizada com sucesso!");
        }

        /// <summary>
        /// Cancela a compra
        /// </summary>
        public void CancelarCompra()
        {
            Status = "Cancelada";
            Console.WriteLine($"Compra {Id} cancelada!");
        }

        /// <summary>
        /// Calcula o valor total da compra
        /// </summary>
        private void CalcularValorTotal()
        {
            ValorTotal = 0;
            foreach (var item in Itens)
            {
                ValorTotal += item.CalcularSubtotal();
            }
            Console.WriteLine($"Valor total da compra: R$ {ValorTotal:F2}");
        }
    }
}
