using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.shared.Model
{
    public class PaginaList<T> : List<T>
    {
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanhoPorPagina { get; set; }
        public int Total { get; set; }

        public PaginaList(IEnumerable<T> items, int pageNumber, int pageSize, int count)
        {
            PaginaAtual = pageNumber;
            TotalPaginas = (int)Math.Ceiling(count / (double)pageSize);
            TamanhoPorPagina = pageSize;
            Total = count;

            AddRange(items);
        }

        public PaginaList(IEnumerable<T> items, int currentPage, int totalPages, int pageSize, int totalCount)
        {
            PaginaAtual = currentPage;
            TotalPaginas = totalPages;
            TamanhoPorPagina = pageSize;
            Total = totalCount;

            AddRange(items);
        }
    }
}
