using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public static class SessionManager
    {
        public static Usuario CurrentUser { get; private set; }
        public static int CurrentUserId { get; private set; } // ID del usuario (PK de la tabla users)
        public static int? CurrentSpecificRoleId { get; private set; } // ID específico del rol (IdAdministrador o IdVendedor)
        public static string CurrentUserRoleName { get; private set; } // Nombre del Rol (Admin, Vendedor)


        public static void SetCurrentUser(Usuario user)
        {
            CurrentUser = user;
            CurrentSpecificRoleId = null;
            CurrentUserRoleName = null;
            CurrentUserId = 0;


            if (user != null)
            {
                CurrentUserId = user.IdUsuario; // Siempre almacenamos el IdUsuario
                CurrentUserRoleName = user.Rol?.Nombre; // Almacenamos el nombre del rol

                if (user is Administrador adminUser)
                {
                    CurrentSpecificRoleId = adminUser.IdAdministrador; // Este es el PK de la tabla 'administrators'
                }
                else if (user is Vendedor vendedorUser)
                {
                    CurrentSpecificRoleId = vendedorUser.IdVendedor; // Este es el PK de la tabla 'sellers'
                }
            }
        }

        public static void ClearSession()
        {
            CurrentUser = null;
            CurrentUserId = 0;
            CurrentSpecificRoleId = null;
            CurrentUserRoleName = null;
        }

        public static bool IsUserLoggedIn()
        {
            return CurrentUser != null && CurrentUserId > 0;
        }

        // Este método ahora valida usando el IdUsuario general
        public static bool IsUserAdminActive()
        {
            return IsUserLoggedIn() &&
                   CurrentUser is Administrador && // Verifica el tipo
                   CurrentUser.Activo &&           // Verifica que el usuario esté activo
                   CurrentUserRoleName?.ToUpper() == "ADMIN"; // Verifica el nombre del rol
        }
        public static bool IsUserVendedorActive()
        {
            return IsUserLoggedIn() &&
                   CurrentUser is Vendedor &&
                   CurrentUser.Activo &&
                   CurrentUserRoleName?.ToUpper() == "VENDEDOR";
        }

        // Si necesitas específicamente el ID de la tabla 'administrators'
        public static int? GetCurrentAdminTableId()
        {
            if (CurrentUser is Administrador adminUser)
            {
                return adminUser.IdAdministrador;
            }
            return null;
        }
    }
}
