using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIEstacionamento.Models;

[Table("Carros")]
public class Carro
{
    [Key]
    public int CarroId { get; set; }
    [Required]
    [StringLength(7)]
    public string? Placa { get; set; }
    [Required]
    [StringLength (11)]
    public string? Renavan { get; set; }
    [Required]
    [StringLength(11)]
    public string? Cpf { get; set; }
    [Required]
    [StringLength(30)]
    public string? Marca { get; set; }
    [Required]
    [StringLength(30)]
    public string? Modelo { get; set; }
    [Required]
    public TipoCombustivel TipoCombustivel { get; set; }// apenas tipos especificos
}
