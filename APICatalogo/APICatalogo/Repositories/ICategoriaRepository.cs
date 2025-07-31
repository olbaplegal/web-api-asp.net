using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories;

public interface ICategoriaRepository : IRepository<Categoria>
{
    Task<PagedList<Categoria>> GetCateoriasAsync(CategoriasParameters categoriasParams);
    Task<PagedList<Categoria>> GetCateoriasFiltroNomeAsync(CategoriasFiltroNome categoriasParams);
}
