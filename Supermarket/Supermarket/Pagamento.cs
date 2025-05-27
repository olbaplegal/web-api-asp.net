using System;
using System.Collections.Generic;

namespace Supermercado
{
    /// <summary>
    /// Classe que representa um pagamento no supermercado
    /// </summary>
    public class Pagamento
    {
        // Atributos
        private string Id { get; set; }
        private double Valor { get; set; }
        private DateTime Data { get; set; }
        private string Metodo { get; set; }
        private string Status { get; set; }

        /// <summary>
        /// Construtor da classe Pagamento
        /// </summary>
        public Pagamento()
        {
            Id = Guid.NewGuid().ToString();
            Data = DateTime.Now;
            Status = "Pendente";
        }

        /// <summary>
        /// Construtor da classe Pagamento com parâmetros
        /// </summary>
        /// <param name="valor">Valor do pagamento</param>
        /// <param name="metodo">Método de pagamento</param>
        public Pagamento(double valor, string metodo)
        {
            Id = Guid.NewGuid().ToString();
            Valor = valor;
            Metodo = metodo;
            Data = DateTime.Now;
            Status = "Pendente";
        }

        /// <summary>
        /// Processa o pagamento
        /// </summary>
        public void Processar()
        {
            // Simulação de processamento de pagamento
            Status = "Processado";
            Console.WriteLine($"Pagamento de R$ {Valor:F2} processado com sucesso! Método: {Metodo}");
        }

        /// <summary>
        /// Estorna o pagamento
        /// </summary>
        /// <returns>True se o estorno foi bem-sucedido, False caso contrário</returns>
        public bool Estornar()
        {
            if (Status == "Processado")
            {
                Status = "Estornado";
                Console.WriteLine($"Pagamento de R$ {Valor:F2} estornado com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Não é possível estornar um pagamento que não foi processado.");
                return false;
            }
        }

        /// <summary>
        /// Emite um comprovante de pagamento
        /// </summary>
        public void EmitirComprovante()
        {
            string comprovante = "===== COMPROVANTE DE PAGAMENTO =====\n";
            comprovante += $"ID: {Id}\n";
            comprovante += $"Data: {Data}\n";
            comprovante += $"Valor: R$ {Valor:F2}\n";
            comprovante += $"Método: {Metodo}\n";
            comprovante += $"Status: {Status}\n";
            comprovante += "===================================\n";
            
            Console.WriteLine(comprovante);
        }
    }
}
