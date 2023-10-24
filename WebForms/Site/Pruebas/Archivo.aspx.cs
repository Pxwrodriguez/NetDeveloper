using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Site.Pruebas
{
    public partial class Archivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargarArchivo()
        {
            var file = HttpContext.Current.Request.Files[0];
            var filenombre = Path.GetFileName(file.FileName);
            var fileruta = @"C:\BD\" + filenombre;
            var serverretura = HttpContext.Current.Server.MapPath("~/Images/" + filenombre);
            file.SaveAs(serverretura);
            return "Archivo subido exitosamente";
        }
    }
}