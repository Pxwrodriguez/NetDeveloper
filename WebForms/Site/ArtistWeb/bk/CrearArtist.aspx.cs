using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.App_Code;

namespace WebForms.Site.ArtistWeb
{
    public partial class CrearArtist : BasePage
    {
        private UnitOfWork _unit;
        public CrearArtist()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VerifyUser();
                IsUserInRole("ADMIN");
               
            }
        }

        protected void btncrear_Click(object sender, EventArgs e)
        {
            var artista = new Artist { Name = txtname.Text };
            _unit.Artists.Add(artista);
            if (_unit.Complete()>0)
            {
                Response.Redirect("ListaArtist.aspx");
            }
        }
    }
}