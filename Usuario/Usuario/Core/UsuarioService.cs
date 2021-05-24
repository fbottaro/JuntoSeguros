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

        public UsuarioService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public virtual ApplicationUser Obter(string email)
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

        public virtual IEnumerable<ApplicationUser> ListarTodos()
        {
            return _userManager.Users
                .OrderBy(p => p.UserName).ToList();
        }

        public virtual bool Incluir(string p_user, string pwd)
        {
            var user = new ApplicationUser { UserName = p_user, Email = p_user };
            var resultado = _userManager
                   .CreateAsync(user, pwd).Result;

            if (resultado.Succeeded)
            {
                _userManager.AddToRoleAsync(user, Roles.ROLE_API_USUARIO).Wait();
            }
            return resultado.Succeeded;
        }

        public virtual bool ChangePassword(string email, string password, string newpassword)
        {
            var user = _userManager.Users.Where(
                    p => p.Email == email).FirstOrDefault();
            return _userManager.ChangePasswordAsync(user, password, newpassword).Result.Succeeded;
        }

        public virtual bool Atualizar(string email, string PhoneNumber)
        {
            var user = _userManager.Users.Where(
                    p => p.Email == email).FirstOrDefault();
            user.PhoneNumber = PhoneNumber;
            return _userManager.UpdateAsync(user).Result.Succeeded;
        }

        public virtual bool Excluir(string email)
        {
            return _userManager.DeleteAsync(_userManager.Users.Where(
                   p => p.Email == email).FirstOrDefault()).Result.Succeeded;
        }
    }
}