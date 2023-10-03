using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Domain.Entities
{
    public class Fornecedor
    {
        public Fornecedor(int codigo, string razaoSocial, string cNPJ, bool ativo, DateTime dataCadastro, string emailContato)
        {
            Codigo = codigo;
            RazaoSocial = razaoSocial;
            CNPJ = cNPJ;
            Ativo = ativo;
            DataCadastro = dataCadastro;
            EmailContato = emailContato;
        }

        public int Codigo { get; private set; }
        public string RazaoSocial { get; private set; }
        public string CNPJ { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string EmailContato { get; private set; }

    }
}
