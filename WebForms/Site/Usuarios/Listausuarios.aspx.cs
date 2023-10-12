using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.App_Code;

namespace WebForms.Site.Usuarios
{
    public partial class Listausuarios : BasePage
    {

        private UnitOfWork _unit;

        public Listausuarios()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IEnumerable<Usuario> usuarios = _unit.Usuarios.GetUsuarios();
                List<Usuario> listausuarios = usuarios.ToList();
                GridViewUsuarios.DataSource = listausuarios;
                GridViewUsuarios.DataBind();
            }
        }
    }
}