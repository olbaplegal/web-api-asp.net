using System;

namespace Supermercado
{
    /// <summary>
    /// Classe principal do programa para demonstrar o uso das classes do sistema de supermercado
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Método principal que inicia a execução do programa
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Supermercado - Demonstração");
            Console.WriteLine("=====================================");
            
            // Criando um fornecedor
            var fornecedor = new Fornecedor();
            fornecedor.Cadastrar();
            
            // Criando produtos
            var produto1 = new Produto("001", "maçã", 2.25, "123", 0.5, "apple", new DateTime(2025, 1, 1), Categoria.Hortifruti);
            var produto2 = new Produto("002", "pera", 2.25, "2344", 0.5, "peraman", new DateTime(2025, 2, 3), Categoria.Hortifruti);
            
            // Criando uma compra
            var compra = new Compra();
            compra.AdicionarItem();
            compra.FinalizarCompra();
            
            // Criando um cliente
            var cliente = new Cliente();
            cliente.Cadastrar();
            cliente.AcumularPontos();
            
            // Criando um caixa
            var caixa = new Caixa();
            caixa.Abrir(1000);
            
            // Criando uma venda
            var venda = new Venda();
            var itemVenda = new ItemVenda(produto1, 2, 2.25);
            venda.AdicionarItem(itemVenda);
            venda.FinalizarVenda("Cartão de Crédito");
            
            // Criando um pagamento
            var pagamento = new Pagamento(100.50, "Cartão de Débito");
            pagamento.Processar();
            pagamento.EmitirComprovante();
            
            // Fechando o caixa
            caixa.Fechar();
            
            Console.WriteLine("\nDemonstração concluída com sucesso!");
        }
    }
}
