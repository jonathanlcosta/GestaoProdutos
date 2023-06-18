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
        PaginacaoConsulta<FornecedorResponse> Listar(FornecedorListarRequest request);
        FornecedorResponse Recuperar(int id);
        FornecedorResponse Inserir(FornecedorInserirRequest request);
        FornecedorResponse Editar(int id, FornecedorEditarRequest request);
        void Excluir(int id);
    }
}