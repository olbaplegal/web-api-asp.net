using System;
using System.Collections.Generic;

namespace Supermercado
{
    /// <summary>
    /// Classe que representa uma venda realizada no supermercado
    /// </summary>
    public class Venda
    {
        // Atributos
        private string Id { get; set; }
        private DateTime Data { get; set; }
        public double ValorTotal { get; set; }
        private string Status { get; set; }
        private Cliente Cliente { get; set; }
        private List<ItemVenda> Itens { get; set; }
        private string FormaPagamento { get; set; }

        /// <summary>
        /// Construtor da classe Venda
        /// </summary>
        public Venda()
        {
            Id = Guid.NewGuid().ToString();
            Data = DateTime.Now;
            Itens = new List<ItemVenda>();
            Status = "Em andamento";
        }

        /// <summary>
        /// Adiciona um item à venda
        /// </summary>
        /// <param name="item">Item a ser adicionado</param>
        public void AdicionarItem(ItemVenda item)
        {
            Itens.Add(item);
            CalcularValorTotal();
            Console.WriteLine("Item adicionado à venda!");
        }

        /// <summary>
        /// Remove um item da venda
        /// </summary>
        /// <param name="item">Item a ser removido</param>
        public void RemoverItem(ItemVenda item)
        {
            Itens.Remove(item);
            CalcularValorTotal();
            Console.WriteLine("Item removido da venda!");
        }

        /// <summary>
        /// Finaliza a venda
        /// </summary>
        /// <param name="formaPagamento">Forma de pagamento utilizada</param>
        public void FinalizarVenda(string formaPagamento)
        {
            FormaPagamento = formaPagamento;
            Status = "Finalizada";
            
            // Se houver cliente, acumula pontos
            if (Cliente != null)
            {
                Cliente.AcumularPontos();
            }
            
            Console.WriteLine($"Venda {Id} finalizada com sucesso! Forma de pagamento: {FormaPagamento}");
        }

        /// <summary>
        /// Cancela a venda
        /// </summary>
        public void CancelarVenda()
        {
            Status = "Cancelada";
            Console.WriteLine($"Venda {Id} cancelada!");
        }

        /// <summary>
        /// Calcula o valor total da venda
        /// </summary>
        private void CalcularValorTotal()
        {
            ValorTotal = 0;
            foreach (var item in Itens)
            {
                ValorTotal += item.CalcularSubtotal();
            }
            Console.WriteLine($"Valor total da venda: R$ {ValorTotal:F2}");
        }

        /// <summary>
        /// Aplica um desconto à venda
        /// </summary>
        /// <param name="percentual">Percentual de desconto a ser aplicado</param>
        public void AplicarDesconto(double percentual)
        {
            if (percentual > 0 && percentual <= 100)
            {
                double valorDesconto = ValorTotal * (percentual / 100);
                ValorTotal -= valorDesconto;
                Console.WriteLine($"Desconto de {percentual}% aplicado. Novo valor total: R$ {ValorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Percentual de desconto inválido!");
            }
        }

        /// <summary>
        /// Emite o cupom fiscal da venda
        /// </summary>
        /// <returns>String contendo o cupom fiscal</returns>
        public string EmitirCupomFiscal()
        {
            string cupom = "===== CUPOM FISCAL =====\n";
            cupom += $"Data: {Data}\n";
            cupom += $"ID: {Id}\n";
            
            if (Cliente != null)
                cupom += $"Cliente: {Cliente}\n";
            
            cupom += "Itens:\n";
            
            foreach (var item in Itens)
            {
                cupom += $"- {item}\n";
            }
            
            cupom += $"Valor Total: R$ {ValorTotal:F2}\n";
            cupom += $"Forma de Pagamento: {FormaPagamento}\n";
            cupom += "=======================\n";
            
            Console.WriteLine("Cupom fiscal emitido com sucesso!");
            return cupom;
        }
    }
}
