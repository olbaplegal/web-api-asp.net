using System;
using System.Collections.Generic;

namespace Supermercado
{
    /// <summary>
    /// Classe que representa um caixa do supermercado
    /// </summary>
    public class Caixa
    {
        // Atributos
        private int NumeroCaixa { get; set; }
        private string Status { get; set; }
        private double SaldoInicial { get; set; }
        private double SaldoAtual { get; set; }
        private DateTime DataAbertura { get; set; }
        private DateTime? DataFechamento { get; set; }
        private List<Venda> Vendas { get; set; }

        /// <summary>
        /// Construtor da classe Caixa
        /// </summary>
        public Caixa()
        {
            Status = "Fechado";
            Vendas = new List<Venda>();
        }

        /// <summary>
        /// Abre o caixa para iniciar as operações
        /// </summary>
        /// <param name="saldoInicial">Saldo inicial do caixa</param>
        public void Abrir(double saldoInicial)
        {
            if (Status == "Fechado")
            {
                SaldoInicial = saldoInicial;
                SaldoAtual = saldoInicial;
                DataAbertura = DateTime.Now;
                Status = "Aberto";
                Console.WriteLine($"Caixa {NumeroCaixa} aberto com saldo inicial de R$ {SaldoInicial:F2}");
            }
            else
            {
                Console.WriteLine($"Caixa {NumeroCaixa} já está aberto!");
            }
        }

        /// <summary>
        /// Fecha o caixa ao final das operações
        /// </summary>
        /// <returns>O saldo final do caixa</returns>
        public double Fechar()
        {
            if (Status == "Aberto")
            {
                Status = "Fechado";
                DataFechamento = DateTime.Now;
                Console.WriteLine($"Caixa {NumeroCaixa} fechado com saldo final de R$ {SaldoAtual:F2}");
                return SaldoAtual;
            }
            else
            {
                Console.WriteLine($"Caixa {NumeroCaixa} já está fechado!");
                return 0;
            }
        }

        /// <summary>
        /// Registra uma venda no caixa
        /// </summary>
        /// <param name="venda">A venda a ser registrada</param>
        public void RegistrarVenda(Venda venda)
        {
            if (Status == "Aberto")
            {
                Vendas.Add(venda);
                SaldoAtual += venda.ValorTotal;
                Console.WriteLine($"Venda registrada no caixa {NumeroCaixa}. Valor: R$ {venda.ValorTotal:F2}");
            }
            else
            {
                Console.WriteLine($"Não é possível registrar venda. Caixa {NumeroCaixa} está fechado!");
            }
        }

        /// <summary>
        /// Realiza uma sangria (retirada de dinheiro) do caixa
        /// </summary>
        /// <param name="valor">Valor a ser retirado</param>
        /// <returns>True se a sangria foi bem-sucedida, False caso contrário</returns>
        public bool RealizarSangria(double valor)
        {
            if (Status == "Aberto" && SaldoAtual >= valor)
            {
                SaldoAtual -= valor;
                Console.WriteLine($"Sangria de R$ {valor:F2} realizada no caixa {NumeroCaixa}. Saldo atual: R$ {SaldoAtual:F2}");
                return true;
            }
            else
            {
                Console.WriteLine("Não foi possível realizar a sangria. Verifique se o caixa está aberto e se há saldo suficiente.");
                return false;
            }
        }

        /// <summary>
        /// Gera um relatório das operações do caixa
        /// </summary>
        /// <returns>String contendo o relatório</returns>
        public string GerarRelatorio()
        {
            string relatorio = $"Relatório do Caixa {NumeroCaixa}\n";
            relatorio += $"Status: {Status}\n";
            relatorio += $"Data de Abertura: {DataAbertura}\n";
            
            if (DataFechamento.HasValue)
                relatorio += $"Data de Fechamento: {DataFechamento.Value}\n";
            
            relatorio += $"Saldo Inicial: R$ {SaldoInicial:F2}\n";
            relatorio += $"Saldo Atual: R$ {SaldoAtual:F2}\n";
            relatorio += $"Total de Vendas: {Vendas.Count}\n";
            
            Console.WriteLine("Relatório gerado com sucesso!");
            return relatorio;
        }
    }
}
