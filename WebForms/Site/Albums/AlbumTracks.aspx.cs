using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Site.Albums
{
    public partial class AlbumTracks : System.Web.UI.Page
    {
        private UnitOfWork _unit;

        public AlbumTracks()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_lista();
                //cargar_datos(1);
            }
            
        }

        private void cargar_datos(int albumid)
        {
            Album album =_unit.Albums.GetAlbumWithTracks(albumid);
            List<Album> listaalbum = new List<Album>();
            listaalbum.Add(album);
            GridViewAlbums.DataSource = listaalbum;
            GridViewAlbums.DataBind();
        }

        private void cargar_lista()
        {
            List<Album> listaalbum = _unit.Albums.GetAll().ToList();
            GridViewLista.DataSource = listaalbum;
            GridViewLista.DataBind();
        }

        protected void GridViewLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            string albumid = GridViewLista.SelectedRow.Cells[1].Text;
            cargar_datos(Convert.ToInt32(albumid));
        }
    }
}