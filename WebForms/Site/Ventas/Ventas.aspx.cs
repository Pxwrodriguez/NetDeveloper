using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Site.Ventas
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargar_combo();
            }
            
        }

        public void cargar_combo()
        {
            string cadenacnx = "Data Source=.;Initial Catalog=Chinook;Integrated Security=True";
            DataTable dtpaises = new DataTable();
            List<string> listapaises = new List<string>();
            using (SqlConnection conexion = new SqlConnection(cadenacnx))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("Select distinct Country from [dbo].[Customer]", conexion))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        dtpaises.Load(reader);
                    }
                }
            }
            DropDownpais.DataSource = dtpaises;
            DropDownpais.DataTextField = "Country";
            DropDownpais.DataValueField = "Country";
            DropDownpais.DataBind();
        }

        [WebMethod]
        public static List<Customer> GetCustomer(string Country)
        {
            using (var unit = new UnitOfWork(new ChinookContext()))
            {
                var customers = unit.Customers.GetListaCustomer(Country);
                List<Customer> listacustomer = customers.ToList();
                return listacustomer;
            }
        }
    }
}