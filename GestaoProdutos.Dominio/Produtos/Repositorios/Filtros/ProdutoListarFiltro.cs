using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.Dominio.Produtos.Repositorios.Filtros
{
    public class ProdutoListarFiltro
    {
        public int Codigo { get; set; }
        public string Descricao {get; set;}
        public DateTime DataFabricacao {get;set;}
        public DateTime DataValidade {get;set;}
        public int IdFornecedor {get; set;}
    }
}