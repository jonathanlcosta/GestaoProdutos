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
        Fornecedor Validar(int id);
        Fornecedor Inserir(FornecedorComando comando);
        Fornecedor Instanciar(FornecedorComando comando);
        Fornecedor Editar(int id, FornecedorComando comando);
    }
}