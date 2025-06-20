using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration; // criando Iconfiguration privada somente leitura para que não seja alterada.

        public CategoriasController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            try
            {
                throw new DataMisalignedException();
                //return _context.Categorias.AsNoTracking().ToList(); //AsNoTracking para melhorar o desempenho da consulta mas só se o retorno não for alterado
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação..");
            }
            //tratando erros nos métodos
            
        }

        [HttpGet("LerArquivoConfiguracao")]
        public string GetValores()
        {
            var valor1 = _configuration ["chave1"];
            var valor2 = _configuration ["chave2"];

            var secao1 = _configuration ["secao1:chave2"];

            return $"Chave1 = {valor1}\n Chave2 = {valor2}\n Secao1:Chave2 = {secao1}";
        }

        [HttpGet("UsandoFromServices/{nome}")] // usando from services
        public ActionResult<string> GetSaudacaoFromServices([FromServices] IMeuServico meuServico, string nome)
        {
            return meuServico.Saudacao(nome);
        }

        [HttpGet("SemUsarFromServices/{nome}")] // sem usar from services
        public ActionResult<string> GetSaudacaoSemFromServices(IMeuServico meuServico, string nome)
        {
            return meuServico.Saudacao(nome);
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {

            //throw new Exception("Exceção ao retornar a categoria pelo Id");
            string[] teste = null;
            if(teste.Length > 0)
            {

            }

            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
            if(categoria == null)
            {
                return NotFound("Categoria não encontrada...");
            }
            return Ok(categoria);
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            //return _context.Categorias.Include(p=>p.Produtos).ToList();
            return _context.Categorias.Include(p => p.Produtos).Where(c => c.CategoriaId <= 5).ToList(); // nunca retornar todos os objetos, sempre filtrar!!
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
                return BadRequest();

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria",
                new {id = categoria.CategoriaId}, categoria); 
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = EntityState.Modified; //só esse método usa o entityframeworkcore
            _context.SaveChanges();
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> Delete(int id) //porque alguns tem que abrir uma lista e outros não no ActionResult? esse pode simplificar mas a pergunta persiste
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
            
            if(categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }
    }
}
