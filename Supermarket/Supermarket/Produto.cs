using System;
using System.Collections.Generic;

namespace Supermercado
{
    public class Produto
    {
        public Produto(string id, string nome, double preco, string codigoBarras, double peso, string marca, DateTime dataValidade, Categoria categoria)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            CodigoBarras = codigoBarras;
            Peso = peso;
            Marca = marca;
            DataValidade = dataValidade;
            Categoria = categoria;
        }

        private string Id { get; set; }
        private string Nome { get; set; }
        private double Preco { get; set; }
        private string CodigoBarras { get; set; }
        private double Peso { get; set; }
        private string Marca { get; set; }
        private DateTime DataValidade { get; set; }
        public Categoria Categoria { get; set; }



        public bool VerificarValidade()
        {
            return DateTime.Now < DataValidade;
        }

        public void AtualizarPreco()
        {
            Console.WriteLine($"Preço do produto {Nome} atualizado com sucesso!");
        }

        public void AplicarDesconto()
        {
            Console.WriteLine($"Desconto aplicado ao produto {Nome}!");
        }
    }
}
