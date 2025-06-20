﻿using APICatalogo.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;

[Table("Produtos")]
public class Produto : IValidatableObject
{
    [Key]
    public int ProdutoId { get; set; }
    [Required]
    [StringLength(80)]
    //[PrimeiraLetraMaiuscula] // validação personalizada via attribute
    public string? Nome { get; set; }
    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }
    [Required]
    [Column(TypeName="decimal(10,2)")]
    public decimal Preco { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    public int CategoriaId { get; set; }
    [JsonIgnore] //vai ser ignorada na serialização e descerialização
    public Categoria? Categoria { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    { 
        if (!string.IsNullOrEmpty(this.Nome))
        {
            var primeiraLetra = this.Nome[0].ToString();
            if (primeiraLetra != primeiraLetra.ToUpper())
            {
               yield return new // yield indica que o método é um enumerador
                    ValidationResult("A primeira letra do Nome do produto deve ser maiúscula.",new[]{nameof(Nome)});
            }
        }

        if(this.Estoque <= 0)
        {
            yield return new
                   ValidationResult("O estoque deve ser maior que zero",
                   new[]
                   { nameof(Estoque) }
                   );
        }
    }
}

