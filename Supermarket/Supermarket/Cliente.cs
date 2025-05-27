using System;

namespace Supermercado
{
    /// <summary>
    /// Classe que representa um cliente do supermercado
    /// </summary>
    public class Cliente
    {
        // Atributos
        private string Id { get; set; }
        private string Nome { get; set; }
        private string Cpf { get; set; }
        private string Endereco { get; set; }
        private string Telefone { get; set; }
        private string Email { get; set; }
        private int PontosFidelidade { get; set; }
        private CartaoFidelidade CartaoFidelidade { get; set; }

        /// <summary>
        /// Construtor da classe Cliente
        /// </summary>
        public Cliente()
        {
            Id = Guid.NewGuid().ToString();
            PontosFidelidade = 0;
        }

        /// <summary>
        /// Cadastra um novo cliente no sistema
        /// </summary>
        public void Cadastrar()
        {
            Console.WriteLine($"Cliente {Nome} cadastrado com sucesso!");
            // Implementação do cadastro no banco de dados ou sistema de armazenamento
        }

        /// <summary>
        /// Atualiza os dados do cliente
        /// </summary>
        public void Atualizar()
        {
            Console.WriteLine($"Dados do cliente {Nome} atualizados com sucesso!");
            // Implementação da atualização no banco de dados ou sistema de armazenamento
        }

        /// <summary>
        /// Acumula pontos de fidelidade para o cliente
        /// </summary>
        public void AcumularPontos()
        {
            // Implementação simples: adiciona 10 pontos
            PontosFidelidade += 10;
            Console.WriteLine($"Cliente {Nome} acumulou pontos. Total: {PontosFidelidade}");
        }

        /// <summary>
        /// Resgata pontos de fidelidade do cliente
        /// </summary>
        /// <returns>True se o resgate foi bem-sucedido, False caso contrário</returns>
        public bool ResgatarPontos()
        {
            // Implementação simples: requer pelo menos 100 pontos para resgate
            if (PontosFidelidade >= 100)
            {
                PontosFidelidade -= 100;
                Console.WriteLine($"Cliente {Nome} resgatou 100 pontos. Pontos restantes: {PontosFidelidade}");
                return true;
            }
            else
            {
                Console.WriteLine($"Cliente {Nome} não possui pontos suficientes para resgate.");
                return false;
            }
        }
    }
}
