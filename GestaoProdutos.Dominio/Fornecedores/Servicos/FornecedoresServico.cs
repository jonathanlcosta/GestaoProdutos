using GestaoProdutos.Dominio.Execoes;
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
        public async Task<Fornecedor> EditarAsync(int id, FornecedorComando comando)
        {
            Fornecedor fornecedor = await ValidarAsync(id);
            fornecedor.SetDescricaoFornecedor(comando.Descricao);
            fornecedor.SetCnpj(comando.Cnpj);
            await fornecedoresRepositorio.EditarAsync(fornecedor);
            return fornecedor;
        }

        public async Task<Fornecedor> InserirAsync(FornecedorComando comando)
        {
            Fornecedor fornecedor = Instanciar(comando);
            await fornecedoresRepositorio.InserirAsync(fornecedor);
            return fornecedor;
        }

        public Fornecedor Instanciar(FornecedorComando comando)
        {
            Fornecedor fornecedor = new(comando.Descricao, comando.Cnpj);
            return fornecedor;
        }

        public async Task<Fornecedor> ValidarAsync(int id)
        {
            Fornecedor fornecedor = await fornecedoresRepositorio.RecuperarAsync(id);
            if (fornecedor is null)
            {
                throw new RegraDeNegocioExcecao("Fornecedor não encontrado");
            }
            return fornecedor;
        }
    }
}