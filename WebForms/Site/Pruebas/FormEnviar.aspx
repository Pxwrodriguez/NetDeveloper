<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.master" AutoEventWireup="true" CodeBehind="FormEnviar.aspx.cs" Inherits="WebForms.Site.Pruebas.FormEnviar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
    <input type="text" id="dato" placeholder="Ingresa algo" />
    <input type="button" value="Enviar" onclick="enviarDatos(); return false;" />

    <script type="text/javascript">
        function enviarDatos() {
            var dato = document.getElementById("dato").value;
            var xhr = new XMLHttpRequest();
            xhr.open("POST", "FormRecibir.aspx", true);
            xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            xhr.send("dato=" + dato);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    location.href = "FormRecibir.aspx";
                }
            };
        }
    </script>
</asp:Content>
