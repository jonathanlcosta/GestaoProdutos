using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.DataTransfer.Fornecedores.Request;
using GestaoProdutos.DataTransfer.Fornecedores.Response;
using GestaoProdutos.Dominio.Util;

namespace GestaoProdutos.Aplicacao.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedoresAppServico
    {
        PaginacaoConsulta<FornecedorResponse> Listar(int? pagina, int quantidade, FornecedorListarRequest fornecedorListarRequest);
        FornecedorResponse Recuperar(int id);
        FornecedorResponse Inserir(FornecedorInserirRequest fornecedorInserirRequest);
        FornecedorResponse Editar(int id, FornecedorEditarRequest fornecedorEditarRequest);
        void Excluir(int id);
    }
}