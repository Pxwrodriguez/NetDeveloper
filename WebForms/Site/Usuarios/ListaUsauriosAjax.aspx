<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.master" AutoEventWireup="true" CodeBehind="ListaUsauriosAjax.aspx.cs" Inherits="WebForms.Site.Usuarios.ListaUsauriosAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
    <div id="error" >

    </div>
    <div class="row">
        <h2>Reporte de usuarios </h2>
    </div>
    <div class="row" id="filatop">
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>Usuario</th>
                    <th>Rol</th>
                    <th>UsuarioActual</th>
                </tr>
            </thead>
            <tbody id="usuarioTableBody">

            </tbody>
        </table>
    </div>
    <script >
        $(document).ready(function () {
            cargarUsuarios();
        });
        function cargarUsuarios() {
            $.ajax({
                type: "POST",
                url: 'ListaUsauriosAjax.aspx/ListaUsuarios',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    var usaurioTableBody = $('#usuarioTableBody');
                    usaurioTableBody.empty();
                   
                    if (data.d.length > 0) {

                        $.each(data.d, function (index, usuario) {
                            usaurioTableBody.append('<tr><td>' + usuario.usuario + '</td><td>' + usuario.rol + '</td><td>' + usuario.usuarioactual  + '</td></tr>');
                        });

         
                    } else {
                        usaurioTableBody.append('<tr><td colspan="3">No hay datos</td></tr>');
                    }
                },
                error: function (xhr, status, error) {
                    $('#error').show();
                }
            });
        }

    </script>
</asp:Content>
