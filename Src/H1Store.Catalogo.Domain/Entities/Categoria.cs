using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Domain.Entities
{
    public class Categoria
    {
        public Categoria(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public int Codigo { get; private set; }
        public string Descricao { get; private set; }
    }
}
