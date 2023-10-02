using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Comando;

namespace GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedoresServico
    {
        Task<Fornecedor> ValidarAsync(int id);
        Task<Fornecedor> InserirAsync(FornecedorComando comando);
        Fornecedor Instanciar(FornecedorComando comando);
        Task<Fornecedor> EditarAsync(int id, FornecedorComando comando);
    }
}