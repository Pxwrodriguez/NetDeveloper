using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
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

            if (Session["Filas"] != null)
            {
                var filas = (List<FilaDatos>)Session["Filas"];

                DataTable dt = new DataTable();

                dt.Columns.Add("TrackId");
                dt.Columns.Add("Precio");
                dt.Columns.Add("Cantidad");

                foreach (var fila in filas)
                {

                    DataRow filanueva = dt.NewRow();

                    filanueva["TrackId"] = fila.Trackid;
                    filanueva["Precio"] = fila.Precio;
                    filanueva["Cantidad"] =fila.Cantidad ;
                    dt.Rows.Add(filanueva);
                }

                
                GridDetalle.DataSource = dt;
                GridDetalle.DataBind();
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

        protected void BtnGrabar_Click(object sender, EventArgs e)
        {
            //Invoice
            int customerid =int.Parse(DropDownCliente.SelectedValue);
            DateTime invoicedate = DateTime.Parse(TxtFecha.Text);
            Decimal totalinvoice = Decimal.Parse(TxtTotal.Text);

            var nuevoinvoice = new Invoice
            {
                CustomerId = customerid,
                InvoiceDate = invoicedate,
                Total = totalinvoice
            };

            _unit.Invoices.Add(nuevoinvoice);
            _unit.Complete();

            //InvoiceLine
            int invoiceid = nuevoinvoice.InvoiceId;

            foreach (GridViewRow row in GridDetalle.Rows)
            {
                int trackid = int.Parse(row.Cells[0].Text);
                decimal unitprice = decimal.Parse(row.Cells[1].Text);
                int quantity = int.Parse(row.Cells[2].Text);

                var nuevoinvoiceline = new InvoiceLine
                {
                    InvoiceId = invoiceid,
                    TrackId = trackid,
                    UnitPrice = unitprice,
                    Quantity = quantity
                };

                _unit.InvoiceLines.Add(nuevoinvoiceline);               
            }

            _unit.Complete();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "showmodal", "$('#modalSuccess').modal('show');", true);
        }
    }
}