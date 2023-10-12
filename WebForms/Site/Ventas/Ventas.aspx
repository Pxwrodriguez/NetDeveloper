<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="WebForms.Site.Ventas.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
<div class="jumbotroom">
    <div class="row">
        <h1>Listado de ventas</h1>
    </div>
    <div class="row">
        <asp:DropDownList ID="DropDownpais" runat="server"></asp:DropDownList>
    </div>
    <div>
        <table id="tablacustomer">
            <thead>
                <tr>
                    <th>Cliente</th>
                    <th>Pais</th>
                </tr>
            </thead>
            <tbody>

            </tbody>
        </table>
    </div>
 </div>

 <script type="text/javascript">
     var dropdown = document.getElementById('<%=DropDownpais.ClientID%>');
     dropdown.addEventListener('change', function () {
         var valorseleccionado = dropdown.value;

         $.ajax({
             type: 'POST',
             url: "Ventas.aspx/GetCustomer",
             data: JSON.stringify({ Country: valorseleccionado }),
             dataType: 'json',
             contentType: 'application/json; charset=utf-8',
             success: function (data) {
                 var tabla = $('#tablacustomer');
                 tabla.empty();
                 if (data.d.length > 0) {
                     $.each(data.d, function (index, customer) {
                         tabla.append('<tr><td>' + customer.Cliente + '</td><td>' + customer.Ciudad + '</td></tr>');
                     });
                 } else {
                     tabla.append('<tr><td colspan="2">No hay datos.</td></tr>');
                 }
             },
             error: function (error) {
                 console.log(error);
             }
         });
     });
 </script>

</asp:Content>
