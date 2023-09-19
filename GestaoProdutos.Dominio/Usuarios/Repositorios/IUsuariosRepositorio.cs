using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Genericos;
using GestaoProdutos.Dominio.Usuarios.Entidades;

namespace GestaoProdutos.Dominio.Usuarios.Repositorios
{
    public interface IUsuariosRepositorio : IGenericoRepositorio<Usuario>
    {
        
    }
}