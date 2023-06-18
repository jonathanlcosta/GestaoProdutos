using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Comando;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;

namespace GestaoProdutos.Dominio.Fornecedores.Servicos
{
    public class FornecedoresServico : IFornecedoresServico
    {
        private readonly IFornecedoresRepositorio fornecedoresRepositorio;
        public FornecedoresServico(IFornecedoresRepositorio fornecedoresRepositorio)
        {
            this.fornecedoresRepositorio = fornecedoresRepositorio;
        }
        public Fornecedor Editar(int id, FornecedorComando comando)
        {
            Fornecedor fornecedor = Validar(id);
            fornecedor.SetDescricaoFornecedor(comando.Descricao);
            fornecedor.SetCnpj(comando.Cnpj);
            fornecedoresRepositorio.Editar(fornecedor);
            return fornecedor;
        }

        public Fornecedor Inserir(FornecedorComando comando)
        {
            Fornecedor fornecedor = Instanciar(comando);
            fornecedoresRepositorio.Inserir(fornecedor);
            return fornecedor;
        }

        public Fornecedor Instanciar(FornecedorComando comando)
        {
            Fornecedor fornecedor = new(comando.Descricao, comando.Cnpj);
            return fornecedor;
        }

        public Fornecedor Validar(int id)
        {
            Fornecedor fornecedor = fornecedoresRepositorio.Recuperar(id);
            if (fornecedor is null)
            {
                throw new Exception("Fornecedor não encontrado");
            }
            return fornecedor;
        }
    }
}