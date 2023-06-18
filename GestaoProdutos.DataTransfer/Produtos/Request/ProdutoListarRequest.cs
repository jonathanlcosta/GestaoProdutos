using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Util.Filtros;
using GestaoProdutos.Dominio.Util.Filtros.Enumeradores;

namespace GestaoProdutos.DataTransfer.Produtos.Request
{
    public class ProdutoListarRequest : PaginacaoFiltro
    {
        public int Codigo { get; set; }
        public string Descricao {get; set;}
        public DateTime DataFabricacao {get;set;}
        public DateTime DataValidade {get;set;}
        public int IdFornecedor {get; set;}
        public ProdutoListarRequest() : base(cpOrd:"Descricao", tpOrd: TipoOrdenacaoEnum.Asc)
        {
        }
    }
}