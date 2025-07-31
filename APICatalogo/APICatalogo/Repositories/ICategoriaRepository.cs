using APICatalogo.Models;
using APICatalogo.Pagination;
using X.PagedList;

namespace APICatalogo.Repositories;

public interface ICategoriaRepository : IRepository<Categoria>
{
    Task<IPagedList<Categoria>> GetCateoriasAsync(CategoriasParameters categoriasParams);
    Task<IPagedList<Categoria>> GetCateoriasFiltroNomeAsync(CategoriasFiltroNome categoriasParams);
}
