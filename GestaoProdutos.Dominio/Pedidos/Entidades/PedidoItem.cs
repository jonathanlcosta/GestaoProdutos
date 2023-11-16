using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Pedidos.Enumeradores;
using GestaoProdutos.Dominio.Produtos.Entidades;

namespace GestaoProdutos.Dominio.Pedidos.Entidades
{
    public class PedidoItem
    {

        public virtual int Id { get; protected set; }
        public virtual Produto Produto { get; protected set; }
        public virtual double ValorUnitario { get; protected set; }
        public virtual PedidoPacote Pacote { get; protected set; }
        public virtual int Quantidade { get; protected set; }
        public virtual string MotivoCancelamento { get; protected set; }
        public virtual SituacaoPedidoItemEnum Situacao { get; protected set; }
        protected PedidoItem(){}
        public PedidoItem(Produto produto, double valorUnitario, PedidoPacote pacote)
        {
            Produto = produto;
            ValorUnitario = valorUnitario;
            Situacao = SituacaoPedidoItemEnum.Pendente;
            Pacote = pacote;
        }

        public virtual void SetMotivoCancelamento(string motivoCancelamento)
        {
           MotivoCancelamento = motivoCancelamento;
        }

        public virtual void SetSituacao(SituacaoPedidoItemEnum  situacao)
        {
            Situacao = situacao;
        }

        public virtual void SetPedidoPacote(PedidoPacote pacote)
        {
            Pacote = pacote;
        }
    }
}