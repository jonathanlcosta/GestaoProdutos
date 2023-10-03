using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Repositorios;
using GestaoProdutos.Dominio.Pedidos.Servicos.Comandos;
using GestaoProdutos.Dominio.Pedidos.Servicos.Interfaces;

namespace GestaoProdutos.Dominio.Pedidos.Servicos
{
    public class PedidoServico : IPedidosServico
    {
        private readonly IPedidosRepositorio pedidosRepositorio;

        public PedidoServico(IPedidosRepositorio pedidosRepositorio)
        {
            this.pedidosRepositorio = pedidosRepositorio;
        }

        public Task<Pedido> EditarAsync(PedidoComando comando)
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> InserirAsync(PedidoComando comando)
        {
            throw new NotImplementedException();
        }

        public Pedido Instanciar(PedidoComando comando)
        {
           return new Pedido(comando.Descricao);
        }

        public Task<Pedido> ValidarAsync(int codigo)
        {
            throw new NotImplementedException();
        }
    }
}