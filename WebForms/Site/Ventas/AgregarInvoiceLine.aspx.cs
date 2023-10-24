using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Site.Ventas
{
    public partial class AgregarInvoiceLine : System.Web.UI.Page
    {
        private UnitOfWork _unit;

        public AgregarInvoiceLine()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                Cargar_TracksRb(); 
            }
            
        }

        //private void Cargar_Tracks()
        //{
        //    IEnumerable<Track> tracks = _unit.Tracks.GetAll();
        //    List<Track> listatracks = tracks.ToList();

        //    DropDownTracks.DataTextField = "Name";
        //    DropDownTracks.DataValueField = "TrackId";
        //    DropDownTracks.DataSource = listatracks;
        //    DropDownTracks.DataBind();

        //}
        private void Cargar_TracksRb()
        {
            IEnumerable<Track> tracks = _unit.Tracks.GetAll();
            List<Track> listatracks = tracks.ToList();
            foreach (var track in listatracks)
            {
                ListItem listitem = new ListItem();
                listitem.Text = track.Name;
                listitem.Value = track.TrackId.ToString();
                RadioButtonTracks.Items.Add(listitem);
            }
        }
    }
}