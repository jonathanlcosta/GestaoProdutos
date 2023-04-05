using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios;
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
        public Fornecedor Editar(int id, string? descricao, string cnpj)
        {
             var fornecedor = Validar(id);
            if(!string.IsNullOrWhiteSpace(descricao) && fornecedor.Descricao != descricao) fornecedor.SetDescricaoFornecedor(descricao);
            if(!string.IsNullOrWhiteSpace(cnpj) && fornecedor.Cnpj != cnpj) fornecedor.SetCnpj(cnpj);

            fornecedor = fornecedoresRepositorio.Editar(fornecedor);
            return fornecedor;
        }

        public Fornecedor Inserir(Fornecedor fornecedor)
        {
            var fornecedorResponse = fornecedoresRepositorio.Inserir(fornecedor);
           return fornecedorResponse;
        }

        public Fornecedor Instanciar(string descricao, string cnpj)
        {
            var fornecedorResponse = new Fornecedor(descricao, cnpj);
            return fornecedorResponse;
        }

        public Fornecedor Validar(int id)
        {
           var fornecedorResponse = this.fornecedoresRepositorio.Recuperar(id);
            if(fornecedorResponse is null)
            {
                 throw new Exception("Fornecedor não encontrado");
            }
            return fornecedorResponse;
        }
    }
}