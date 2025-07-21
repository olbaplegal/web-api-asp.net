using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories;

public interface ICategoriaRepository : IRepository<Categoria>
{
    PagedList<Categoria> GetCateorias(CategoriasParameters categoriasParams);
    PagedList<Categoria> GetCateoriasFiltroNome(CategoriasFiltroNome categoriasParams);

}
