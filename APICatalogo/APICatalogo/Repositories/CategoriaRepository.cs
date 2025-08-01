﻿using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Pagination;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList;

namespace APICatalogo.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    private readonly AppDbContext _context;

    public CategoriaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IPagedList<Categoria>> GetCateoriasAsync(CategoriasParameters categoriasParams)
    {
        var categorias = await GetAllAsync();

        var categoriasOrdenadas = categorias.OrderBy(p => p.CategoriaId).AsQueryable();

        //var resultado = PagedList<Categoria>.ToPagedList(categoriasOrdenadas, categoriasParams.PageNumber, categoriasParams.PageSize);

        var resultado = await categoriasOrdenadas.ToPagedListAsync(categoriasParams.PageNumber,
                                                             categoriasParams.PageSize);

        return resultado;
    }

    public async Task<IPagedList<Categoria>> GetCateoriasFiltroNomeAsync(CategoriasFiltroNome categoriasParams)
    {
        var categorias = await GetAllAsync();
            

        if (!string.IsNullOrEmpty(categoriasParams.Nome))
        {
            categorias = categorias.Where(c => c.Nome.Contains(categoriasParams.Nome));
        }

        //var categoriasFiltradas = PagedList<Categoria>.ToPagedList(categorias.AsQueryable(), categoriasParams.PageNumber, categoriasParams.PageSize);

        var categoriasFiltradas = await categorias.ToPagedListAsync(categoriasParams.PageNumber,
                                                                    categoriasParams.PageSize);

        return categoriasFiltradas;
    }
}
