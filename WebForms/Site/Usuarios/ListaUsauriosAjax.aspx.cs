using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.App_Code;

namespace WebForms.Site.Usuarios
{
    public partial class ListaUsauriosAjax : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //VerifyUser();
                //IsUserInRole("Admin");
            }
            

        }

        [WebMethod]
        public static IEnumerable<Usuario> ListaUsuarios()
        {
            string usuarioactual = HttpContext.Current.User.Identity.Name;
            using (var unit = new UnitOfWork(new ChinookContext()))
            {
                IEnumerable<Usuario> usuarios = unit.Usuarios.GetUsuarios();
                List<Usuario> listausuarios = usuarios.ToList();

                foreach (var usuario in listausuarios)
                {
                    if (usuario.usuario==usuarioactual)
                    {
                        usuario.usuarioactual = "Si";
                    }
                    else
                    {
                        usuario.usuarioactual = "No";
                    }
                }

                return listausuarios;
                 
            }

        }
    }
}