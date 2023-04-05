using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.DataTransfer.Produtos.Request;
using GestaoProdutos.DataTransfer.Produtos.Response;
using GestaoProdutos.Dominio.Util;

namespace GestaoProdutos.Aplicacao.Produtos.Servicos.Interfaces
{
    public interface IProdutosAppServico
    {
        PaginacaoConsulta<ProdutoResponse> Listar(int? pagina, int quantidade, ProdutoListarRequest produtoListarRequest);
        ProdutoResponse Recuperar(int codigo);
        ProdutoResponse Inserir(ProdutoInserirRequest produtoInserirRequest);
        ProdutoResponse Editar(int codigo, ProdutoEditarRequest produtoEditarRequest);
        void Excluir(int codigo);
    }
}