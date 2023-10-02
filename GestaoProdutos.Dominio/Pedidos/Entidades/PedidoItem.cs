using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Produtos.Entidades;

namespace GestaoProdutos.Dominio.Pedidos.Entidades
{
    public class PedidoItem
    {
        public virtual int Id { get; protected set; }
        public virtual Produto Produto { get; protected set; }
        public virtual decimal ValorUnitario { get; protected set; }
    }
}