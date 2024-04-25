using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.shared.Model
{
    public class CabecalhoPaginacao
    {
        public int paginaAtual { get;private set; }
        public int itemsporPagina { get; private set; }
        public int Total { get; private set; }
        public int TotalPaginas { get; private set; }
        public object items { get; private set; }


        public CabecalhoPaginacao(int paginaAtual, int itemsporPagina, int total,int totalPaginas, object items)
        {
            this.paginaAtual = paginaAtual;
            this.itemsporPagina = itemsporPagina;
            Total = total;
            this.items = items;
            TotalPaginas = totalPaginas;
        }

    }
}
