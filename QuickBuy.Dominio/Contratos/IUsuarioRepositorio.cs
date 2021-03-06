﻿using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Dominio.Contratos
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Usuario Obter(string strEmail, string strSenha);
        Usuario Obter(string strEmail);
    }
}
