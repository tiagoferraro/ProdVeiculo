using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.domain.Entities.Base
{
    public abstract class Entity
    {
        public int Codigo { get; private set; }

        public DateTime DataCadastro { get; private set; }
    }
}
