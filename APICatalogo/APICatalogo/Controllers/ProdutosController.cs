using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;

[Route("[controller]")]//rota vai ser definida usando apenas o nome do controlador
[ApiController]
public class ProdutosController : Controller
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    //criando método action
    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _context.Produtos.ToList();
        if(produtos is null)
        {
            return NotFound("Produtos não encontrados...");
        }
        return produtos;
    }

    //GET por ID
    [HttpGet("{id:int}", Name="ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p=> p.ProdutoId == id);
        if (produto == null)
        {
            return NotFound("Produto não encontrado...");
        }
        return produto;
    }

    [HttpPost]
    public ActionResult Post(Produto produto)// recebe o produto
    {
        if (produto is null)
            return BadRequest();

        _context.Produtos.Add(produto);// incluiu no contexto
        _context.SaveChanges();// persiste os dados na tabela

        return new CreatedAtRouteResult("ObterProduto",//retorna 201 created
            new { id = produto.ProdutoId }, produto);//aciona a rota do get e retorna o produto
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        if(id != produto.ProdutoId)
        {
            return BadRequest();
        }

        _context.Entry(produto).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(produto);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);//localizando produto no banco de dados
        //var produto = _context.Produtos.Find(id);

        if(produto is null)//se não encontrou
        {
            return NotFound("Produto não localizado...");
        }
        _context.Produtos.Remove(produto);//se encontrou, faz a remoção do contexto
        _context.SaveChanges();//persiste as informações

        return Ok(produto);
    }
}
