using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using Usuario.Domain;
using Usuario.Security;

namespace Usuario.Core
{
    public class UsuarioService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsuarioService()
        {
        }

        public ApplicationUser Obter(string email)
        {
            email = email?.Trim().ToUpper();
            if (!String.IsNullOrWhiteSpace(email))
            {
                return _userManager.Users.Where(
                    p => p.Email == email).FirstOrDefault();
            }
            else
                return null;
        }

        public IEnumerable<ApplicationUser> ListarTodos()
        {
            return _userManager.Users
                .OrderBy(p => p.UserName).ToList();
        }

        public bool Incluir(ApplicationUser user)
        {
            var resultado = _userManager
                   .CreateAsync(user).Result;

            if (resultado.Succeeded)
            {
                _userManager.AddToRoleAsync(user, Roles.ROLE_API_USUARIO).Wait();
            }
            return resultado.Succeeded;
        }

        public bool Atualizar(ApplicationUser user)
        {
            return _userManager.UpdateAsync(user).Result.Succeeded;
        }

        public bool Excluir(string email)
        {
            return _userManager.DeleteAsync(_userManager.Users.Where(
                   p => p.Email == email).FirstOrDefault()).Result.Succeeded;
        }
    }
}