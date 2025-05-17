using APIEstacionamento.Context;
using APIEstacionamento.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace APIEstacionamento.Controllers;

[Route("[controller]")]
[ApiController]
public class EstacionamentoController : ControllerBase
{
    private readonly APIEstacionamentoContext _context;

    public EstacionamentoController(APIEstacionamentoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Carro>> GetAll()
    {
        var carros = _context.Carros.ToList(); //trocar o Categorias depois de ajeitar o context
        if (carros is null)
        {
            return NotFound("Carros não encontrados");
        }
        return carros;
    }

    [HttpGet("{id:int}", Name = "ObterProduto")]
    public ActionResult<Carro> GetById(int id)
    {
        var carro = _context.Carros.FirstOrDefault(p => p.CarroId == id); // id do carro tem que ser igual ao id do request
        if (carro == null)
        {
            return NotFound("Carro não encontrado");
        }
        return carro;
    }

    [HttpGet("BuscaSomenteCpf")]
    public ActionResult<Carro> GetByCpf(string cpf)
    {
        var carro = _context.Carros.FirstOrDefault(c => c.Cpf == cpf);

        if(carro is null)
        {
            return BadRequest("Cpf não cadastrado...");
        }

        return carro;
    }
    // precisa tratamento

    [HttpPost]
    public ActionResult Post(Carro carro)
    {
        if (carro is null)
        {
            return BadRequest();
        }

        _context.Carros.Add(carro);
        _context.SaveChanges();
        return new CreatedAtRouteResult("ObterProduto",
            new { id = carro.CarroId }, carro);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Carro carro)
    {
        if (id != carro.CarroId)
        {
            return BadRequest();
        }

        _context.Entry(carro).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(carro);
    }

    [HttpPut("AtualizarComId")]
    public ActionResult AtualizarCarroComId(Carro carro)
    {
        if(carro.CarroId == 0)
        {
            return BadRequest("Id do carro nulo...");
        }

        var carroVelho = _context.Carros.Where(w => w.CarroId == carro.CarroId);

        if (carroVelho == null)
        {
            return BadRequest("não existe...");
        }

        _context.Entry(carro).State = EntityState.Modified;
        _context.SaveChanges();


        return Ok(carro);
    }

    [HttpPut("AtualizarSemId")]
    public ActionResult AtualizarCarroSemId(Carro carro)
    {
        if (carro.Cpf is null || carro.Cpf.Trim().Equals(""))
        {
            return BadRequest("Cpf Motorista nulo...");
        }

        var carroVelho = _context.Carros
            .Where(w => w.Cpf == carro.Cpf)
            .AsNoTracking()
            .FirstOrDefault();

        if (carroVelho == null)
        {
            return BadRequest("não existe...");
        }

        carro.CarroId = carroVelho.CarroId;

        //carroVelho.Cpf = carro.Cpf;
        //carroVelho.Renavan = carro.Renavan;
        //carroVelho.CarroId = carro.CarroId;
        //carroVelho.Placa = carro.Placa;
        //carroVelho.TipoCombustivel = carro.TipoCombustivel;

        _context.Entry(carro).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(carro);
    }

    [HttpPut("AtualizarCombustivelComCpf")]
    public ActionResult UpdateByCpf(string cpf, TipoCombustivel combustivel)
    {
        if (combustivel is 0)
        {
            return BadRequest("cpf nulo...");
        }

        var carro = _context.Carros.FirstOrDefault(c => c.Cpf == cpf);

        if(carro is null)
        {
            return BadRequest("Cpf não cadastrado...");
        }

        carro.TipoCombustivel = combustivel;
        _context.Entry(carro).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(carro);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var carro = _context.Carros.FirstOrDefault(p => p.CarroId == id);
        if (carro is null)
        {
            return NotFound("carro não encontrado...");
        }
        _context.Carros.Remove(carro);
        _context.SaveChanges();

        return Ok(carro);
    }
}
