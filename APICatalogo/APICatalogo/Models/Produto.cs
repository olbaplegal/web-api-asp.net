namespace APICatalogo.Models;
// classes apenas com propriedades são chamadas classes anemicas
public class Produto
{
    public int ProdutoId { get; set; } // ou Id, o Id no nome do atributo faz com
                                       // que seja identificado como chave primaria.
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public string? ImageUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
}
