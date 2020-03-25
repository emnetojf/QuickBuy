using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using QuickBuy.Repositorio.Contexto;
using System.Linq;

namespace QuickBuy.Repositorio.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorios<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(QuickBuyContexto quickBuyContexto) : base(quickBuyContexto)
        {

        }

        public Usuario Obter(string strEmail, string strSenha)
        {
            return QuickBuyContexto.Usuarios.FirstOrDefault(usr => usr.strEmail == strEmail && usr.strSenha == strSenha );
        }
    }
}
