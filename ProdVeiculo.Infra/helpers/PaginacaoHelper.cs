using Microsoft.EntityFrameworkCore;
using ProdVeiculo.shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.Infra.helpers
{
    public static class PaginacaoHelper
    {
        public static async Task<PaginaList<T>> CriarAsync<T>
           (IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take((pageSize)).ToListAsync();
            return new PaginaList<T>(items, pageNumber, pageSize, count);
        }
    }
}
