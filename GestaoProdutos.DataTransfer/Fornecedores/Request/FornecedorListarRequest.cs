using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Util.Filtros;
using GestaoProdutos.Dominio.Util.Filtros.Enumeradores;

namespace GestaoProdutos.DataTransfer.Fornecedores.Request
{
    public class FornecedorListarRequest : PaginacaoFiltro
    {
        public int Id{ get; set;}
        public string Descricao { get; set;}
        public string Cnpj{ get; set;}
        public FornecedorListarRequest() : base(cpOrd:"Descricao", tpOrd: TipoOrdenacaoEnum.Asc)
        {
        }
    }
}