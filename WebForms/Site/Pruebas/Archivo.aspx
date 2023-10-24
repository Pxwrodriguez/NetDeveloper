<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.master" AutoEventWireup="true" CodeBehind="Archivo.aspx.cs" Inherits="WebForms.Site.Pruebas.Archivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
    <div>
        <h1>CARGA DE ARCHIVOS </h1>
        <input type="file" id="fileinput" />
        <button id="upload">Subir archivo</button>
        <div id="uploadprogressbar" style="display:none;">
            Subiendo...<progress id="progressbar" max="100" value="0"></progress>
        </div>
        <div id="uploadfile" style="display:none;">
            Archivo subido : <span id="filename"></span>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#upload").click(function (event) {
                event.preventDefault();
                var fileinput = document.getElementById("fileinput");
                var file = fileinput.files[0];
                if (file) {
                    cargararchivo(file);                    
                }
            });
        });

        function cargararchivo(file){ 
            var formdata = new FormData();
            formdata.append("file", file);
            $.ajax({
                type: "POST",
                url: "Archivo.aspx/CargarArchivo",
                data: formdata,
                contentType:false,
                processData:false,
                success: function (data) {
                    $("#uploadfile").show();
                    $("#filename").text(data);
                    console.log(data);
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }

    </script>
</asp:Content>
