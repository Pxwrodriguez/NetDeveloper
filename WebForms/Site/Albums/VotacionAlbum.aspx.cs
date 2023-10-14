using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Site.Albums
{
    public partial class VotacionAlbum : System.Web.UI.Page
    {
        

        public VotacionAlbum()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool ActualizarVoto(int value)
        {
            int valoractual = GetValoracionAlbum();
            int nuevovalor = valoractual + value;
            bool updated = SetValoracionAlbum(nuevovalor);
            
            return updated;
        }

        private static int GetValoracionAlbum()
        {
            string cadenacnx = "Data Source=.;Initial Catalog=Chinook;Integrated Security=True";
            int valor =0;
            using (SqlConnection conexion = new SqlConnection(cadenacnx))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("Select IsNull(Assessment,0) as Assessment from [dbo].[AlbumAssessment] where Albumid=1", conexion))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            valor = Convert.ToInt32(reader["Assessment"]);
                        }
                    }
                }
            }
            return valor;
        }

        private static bool SetValoracionAlbum(int nuevovalor)
        {
            string cadenacnx = "Data Source=.;Initial Catalog=Chinook;Integrated Security=True";
            using (SqlConnection conexion = new SqlConnection(cadenacnx))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("Update [dbo].[AlbumAssessment] set [Assessment]=@nuevovalor where AlbumId=1", conexion))
                {
                    comando.Parameters.AddWithValue("@nuevovalor", nuevovalor);
                    int filas = comando.ExecuteNonQuery();
                    return (filas > 0);
                }

            }                
        }
    }
}