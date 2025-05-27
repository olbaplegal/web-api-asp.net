using System;

namespace Supermercado
{
    /// <summary>
    /// Classe que representa um fornecedor do supermercado
    /// </summary>
    public class Fornecedor
    {
        // Atributos
        private string Id { get; set; }
        private string RazaoSocial { get; set; }
        private string Cnpj { get; set; }
        private string Endereco { get; set; }
        private string Telefone { get; set; }
        private string Email { get; set; }
        private string Contato { get; set; }

        /// <summary>
        /// Construtor da classe Fornecedor
        /// </summary>
        public Fornecedor()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Cadastra um novo fornecedor no sistema
        /// </summary>
        public void Cadastrar()
        {
            Console.WriteLine($"Fornecedor {RazaoSocial} cadastrado com sucesso!");
            // Implementação do cadastro no banco de dados ou sistema de armazenamento
        }

        /// <summary>
        /// Atualiza os dados do fornecedor
        /// </summary>
        public void Atualizar()
        {
            Console.WriteLine($"Dados do fornecedor {RazaoSocial} atualizados com sucesso!");
            // Implementação da atualização no banco de dados ou sistema de armazenamento
        }

        /// <summary>
        /// Avalia o fornecedor com base em critérios como prazo de entrega, qualidade dos produtos, etc.
        /// </summary>
        public void Avaliar()
        {
            Console.WriteLine($"Avaliação do fornecedor {RazaoSocial} realizada com sucesso!");
            // Implementação da lógica de avaliação do fornecedor
        }
    }
}
