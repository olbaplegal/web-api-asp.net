using APIEstacionamento.Context;
using APIEstacionamento.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public ActionResult<IEnumerable<Carro>> Get()
    {
        var carros = _context.Carros.ToList(); //trocar o Categorias depois de ajeitar o context
        if(carros is null)
        {
            return NotFound("Carros não encontrados");
        }
        return carros;
    }

    [HttpGet("{id:int}", Name="ObterProduto")]
    public ActionResult<Carro> Get(int id)
    {
        var carro = _context.Carros.FirstOrDefault(p => p.CarroId == id); // id do carro tem que ser igual ao id do request
        if (carro == null) 
        {
            return NotFound("Carro não encontrado");
        }
        return carro;
    }

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
            new { id = carro.CarroId}, carro);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Carro carro)
    {
        if(id != carro.CarroId)
        {
            return BadRequest();
        }

        _context.Entry(carro).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(carro);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var carro = _context.Carros.FirstOrDefault(p=>p.CarroId == id);
        if(carro is null)
        {
            return NotFound("carro não encontrado...");
        }
        _context.Carros.Remove(carro);
        _context.SaveChanges();

        return Ok(carro);
    }
}
