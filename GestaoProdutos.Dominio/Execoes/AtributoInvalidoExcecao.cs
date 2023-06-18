using System.Runtime.Serialization;

namespace GestaoProdutos.Dominio.Execoes
{
    public class AtributoInvalidoExcecao : RegraDeNegocioExcecao
    {
        public AtributoInvalidoExcecao()
        {
        }
        public AtributoInvalidoExcecao(string atributo) : base(atributo + " inválido")
        {
        }

        protected AtributoInvalidoExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}

