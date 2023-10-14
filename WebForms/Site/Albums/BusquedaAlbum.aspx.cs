using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Site.Albums
{
    public partial class BusquedaAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        [WebMethod]
        public static List<string> BuscarTitulo(string searchtext)
        {
            using (var unit = new UnitOfWork(new ChinookContext()))
            {
                return unit.Albums.GetTitlesLikeTitle(searchtext);
            }
        }
    }
}