using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Fornecedores.Entidades;

namespace GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedoresServico
    {
        Fornecedor Validar(int id);
        Fornecedor Inserir(Fornecedor fornecedor);
        Fornecedor Instanciar(string descricao, string cnpj);
        Fornecedor Editar(int id, string? descricao, string cnpj);
    }
}