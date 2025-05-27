using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;
// novo route default
[Route("api/[controller]")] // produtos 
[ApiController]
public class ProdutosController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    // criando método action
    // api/produtos
    [HttpGet] // rout default
    [HttpGet("primeiro")] // api/produtos/primeiro
    [HttpGet("teste")] // api/produtos/teste
    [HttpGet("/primeiro")] // /primeiro
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _context.Produtos.ToList();
        if(produtos is null)
        {
            return NotFound("Produtos não encontrados...");
        }
        return produtos;
    }

    //[HttpGet]
    //public string GetString()
    //{
    //    var produto = _context.Produtos.FirstOrDefault();
    //    return ("hello world");
    //}

    //[HttpGet]
    //public Produto GetProduto()
    //{
    //     var produto = _context.Produtos.FirstOrDefault();
        // não é possivel returnar um not found 
        //if (produto is null){
        //    return NotFound();
        //}
    //    return produto;
    //}

    //[HttpGet]
    //public IActionResult GetIActionResult()
    //{
    //    var produto = _context.Produtos.FirstOrDefault();
    //    if (produto is null)
    //    {
    //        return NotFound(); // neste caso o notfound é do tipo IActionResult
    //    }
    //    return Ok(produto); // ok é um IAcitonResult tbm 
    //}

    //[HttpGet]
    // ActionResult<T> tem maior flexibilidade pois da para retornar o produto ou os tipos ActionResults
    //public ActionResult<Produto> GetIActionResultDeT()
    //{
    //    var produto = _context.Produtos.FirstOrDefault();
    //    if (produto is null)
    //    {
    //        return NotFound();
    //    }
    //    return produto;

    //}

    // only accept values of A to Z
    // alpha numerics of lenth == 5
    //[HttpGet("{valor:alpha:length(5)}")] 
    //public ActionResult<Produto> Get2(string valor)
    //{
    //    var teste = valor;
    //    return _context.Produtos.FirstOrDefault();
    //}

    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<Produto>>> GetAsync()
    //{
    //    return await _context.Produtos.AsNoTracking().ToListAsync();
    //}

    // GET por ID
    // api/produtos/id
    //[HttpGet("{id}/{nome=Caderno}", Name="ObterProduto")]
    //public ActionResult<Produto> Get(int id, string nome)
    //public async Task<ActionResult<Produto>> Get(int id,[BindRequired] string nome) // exige que o nome seja inserio na cadeia de consulta
    [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
    public async Task<ActionResult<Produto>> Get([FromQuery]int id) // alterando o comportamento padrão, o Id vai ser recebido da cadeia de consulta
    {
        //var nomeProduto = nome;

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

// fontes
// https://learn.microsoft.com/pt-br/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
// https://learn.microsoft.com/pt-br/aspnet/core/mvc/models/model-binding?view=aspnetcore-9.0