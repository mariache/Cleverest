using Cleverest.BLL.Interfaces;
using Cleverest.Common;
using Cleverest.DAO;
using Cleverest.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cleverest.Models
{
    public static class Authentification
    {
        private static IAuthentificationLogic authLogic = Resolver.AuthentificationLogic;

        public static bool CanLogin(string login, string password) =>
                authLogic.CanLogin(login, password);

    }
}