<%@ Page Title="Crear artista" Language="C#" MasterPageFile="~/Site/MantTemplate.Master" AutoEventWireup="true" CodeBehind="CrearArtist.aspx.cs" Inherits="WebForms.Site.ArtistWeb.CrearArtist" %>

<asp:Content ID="ButtonContent" ContentPlaceHolderID="ButtonContent" runat="server">
    <a class="btn btn-info" href="ListaArtist.aspx">
        <span class="glyphicon glyphicon-hand-left"></span>Regresar
    </a>
</asp:Content>

<asp:Content ID="ArtistContent" ContentPlaceHolderID="ArtistContent" runat="server">
    <h2>Crear nuevo artista</h2>
    <div id="success" class="alert alert-success" role="alert">
        <strong>Success!</strong> Registro creado.
    </div>
    <div id="error" class="alert alert-success" role="alert">
        <strong>Error!</strong> No se pudo crear el registro.
    </div>
    <div class="row">
        <div>
            <label>Nombre artista:" </label>
            <input type="text" required="required" id="Name" />
        </div>
    </div>
    <div class="row">
        <div>
            <button class="btn btn-submit" onclick="insertArtist(); return false;">
                Crear artista
            </button>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            $('.alert').hide();
        })
        function insertArtist() {
            $('.alert').hide();
            var name = document.getElementById('Name').value;
            $.ajax({
                type: "POST",
                url: 'CrearArtist.aspx/InsertArtist',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: "{ 'name':'" + name + "' }",
                success: function (data, status, xhr) {
                    if (data.d == true) {
                        $('#success').show();
                        document.getElementById('Name').value = '';
                    }
                },
                error: function (xhr, status, error) {
                    $('#error').show();
                }
            });
        }


    </script>

</asp:Content>
