using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.Dominio.Usuarios.Entidades
{
    public class Usuario
    {
        public virtual string Nome { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Senha { get; protected set; }
        public virtual DateTime CriadoEm { get; set; }
        protected Usuario()
        {
            
        }

        public Usuario(string nome, string email, string senha)
        {
            SetNome(nome);
            SetEmail(email);
            SetSenha(senha);
            CriadoEm = DateTime.Now;
        }

        public virtual void SetSenha(string senha)
        {
            Senha = senha;
        }

        public virtual void SetEmail(string email)
        {
            Email = email;
        }

        public virtual void SetNome(string nome)
        {
            Nome = nome;
        }
    }
}