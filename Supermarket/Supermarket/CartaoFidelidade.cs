using System;

namespace Supermercado
{
    /// <summary>
    /// Classe que representa um cartão de fidelidade do cliente
    /// </summary>
    public class CartaoFidelidade
    {
        // Atributos
        private string Id { get; set; }
        private string Numero { get; set; }
        private DateTime DataEmissao { get; set; }
        private DateTime DataValidade { get; set; }
        private bool Ativo { get; set; }
        private int PontosAcumulados { get; set; }

        /// <summary>
        /// Construtor da classe CartaoFidelidade
        /// </summary>
        public CartaoFidelidade()
        {
            Id = Guid.NewGuid().ToString();
            DataEmissao = DateTime.Now;
            DataValidade = DateTime.Now.AddYears(2);
            Ativo = true;
            PontosAcumulados = 0;
        }

        /// <summary>
        /// Adiciona pontos ao cartão de fidelidade
        /// </summary>
        /// <param name="pontos">Quantidade de pontos a adicionar</param>
        public void AdicionarPontos(int pontos)
        {
            if (Ativo)
            {
                PontosAcumulados += pontos;
                Console.WriteLine($"Adicionados {pontos} pontos ao cartão {Numero}. Total: {PontosAcumulados}");
            }
            else
            {
                Console.WriteLine($"Não foi possível adicionar pontos. Cartão {Numero} inativo.");
            }
        }

        /// <summary>
        /// Resgata pontos do cartão de fidelidade
        /// </summary>
        /// <param name="pontos">Quantidade de pontos a resgatar</param>
        /// <returns>True se o resgate foi bem-sucedido, False caso contrário</returns>
        public bool ResgatarPontos(int pontos)
        {
            if (Ativo && PontosAcumulados >= pontos)
            {
                PontosAcumulados -= pontos;
                Console.WriteLine($"Resgatados {pontos} pontos do cartão {Numero}. Restantes: {PontosAcumulados}");
                return true;
            }
            else
            {
                Console.WriteLine($"Não foi possível resgatar pontos. Verifique se o cartão está ativo e se há pontos suficientes.");
                return false;
            }
        }

        /// <summary>
        /// Bloqueia o cartão de fidelidade
        /// </summary>
        public void Bloquear()
        {
            Ativo = false;
            Console.WriteLine($"Cartão {Numero} bloqueado.");
        }

        /// <summary>
        /// Desbloqueia o cartão de fidelidade
        /// </summary>
        public void Desbloquear()
        {
            Ativo = true;
            Console.WriteLine($"Cartão {Numero} desbloqueado.");
        }

        /// <summary>
        /// Verifica se o cartão está válido
        /// </summary>
        /// <returns>True se o cartão estiver válido, False caso contrário</returns>
        public bool VerificarValidade()
        {
            return Ativo && DateTime.Now <= DataValidade;
        }
    }
}
