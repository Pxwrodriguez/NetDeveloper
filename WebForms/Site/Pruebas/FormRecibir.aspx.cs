using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Site.Pruebas
{
    public partial class FormRecibir : System.Web.UI.Page
    {
        private static string datorecibido;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Form["dato"]))
                {
                    datorecibido = Request.Form["dato"];
                    Session["midato"] = datorecibido;
                }
            }
            lbldato.Text = Session["midato"].ToString();

        }
    }
}