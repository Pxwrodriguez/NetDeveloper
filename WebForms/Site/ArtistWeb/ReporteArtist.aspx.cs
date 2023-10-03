using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Site.ArtistWeb
{
    public partial class ReporteArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Artist> ListaArtist()
        {
            using (var unit = new UnitOfWork(new ChinookContext()))
            {
                //IEnumerable<Artist> artistas = unit.Artists.GetArtistsByStore();
                IEnumerable<Artist> artistas = unit.Artists.GetArtistsByStore();
                List<Artist> listaartistas = artistas.ToList();
                return listaartistas;
            }

        }
    }
}