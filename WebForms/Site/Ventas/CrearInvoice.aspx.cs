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
    public partial class CrearInvoice : System.Web.UI.Page
    {
        private UnitOfWork _unit;

        public CrearInvoice()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            IEnumerable<Customer> customers= _unit.Customers.GetListaCustomer("USA");
            List<Customer> listacustomer = customers.ToList();
            DropDownCliente.DataSource = listacustomer;
            DropDownCliente.DataValueField = "CustomerId";
            DropDownCliente.DataTextField = "Cliente";
            DropDownCliente.DataBind();
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarInvoiceLine.aspx");
        }
    }
}