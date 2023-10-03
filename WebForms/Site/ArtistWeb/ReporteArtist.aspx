﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.master" AutoEventWireup="true" CodeBehind="ReporteArtist.aspx.cs" Inherits="WebForms.Site.ArtistWeb.ReporteArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
    <div class="row">
        <h2>Reporte de artistas </h2>
    </div>
    <div class="row" id="filatop">
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Nombre artista</th>
                </tr>
            </thead>
            <tbody id="artistTableBody">

            </tbody>
        </table>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            cargarArtistas();
        });

        function cargarArtistas() {
            $.ajax({
                type: "POST",
                url: 'ReporteArtist.aspx/ListaArtist',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',                
                success: function (data) {
                    var artistTableBody = $('#artistTableBody');
                    artistTableBody.empty();

                    if (data.d.length > 0) {
                        $.each(data.d, function (index, artist) {
                            artistTableBody.append('<tr><td>' + artist.Artistid + '</td><td>' + artist.Name + '</td></tr>');
                        });

                        showMensaje("Datos cargados");

                    } else {
                        artistTableBody.append('<tr><td colspan="2">No hay datos</td></tr>');
                    }
                },
                error: function (xhr, status, error) {
                    $('#error').show();
                }
            });
        }

        function showMensaje(message) {
            //alert(message);
            var alertdiv = $('<div class="alert alert-success"></div>');
            alertdiv.text(message);
            $('#filatop').before(alertdiv);

            setTimeout(function () {
                alertdiv.fadeOut(500, function () {
                    alertdiv.remove();
                });
            }, 5000);
        }
    </script>

</asp:Content>
