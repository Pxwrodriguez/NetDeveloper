<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.master" AutoEventWireup="true" CodeBehind="CrearInvoice.aspx.cs" Inherits="WebForms.Site.Ventas.CrearInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
    <div id="modalSuccess" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Éxito</h5>
                </div>
                <div class="modal-body">
                    <p>Los datos se guardaron con éxito.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Aceptar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
    <div class="container">
        <asp:Label ID="Label2" runat="server" Text="Cliente:"></asp:Label>
        <asp:DropDownList ID="DropDownCliente" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Fecha"></asp:Label>
        <asp:TextBox ID="TxtFecha" runat="server" TextMode="DateTime"></asp:TextBox>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <asp:GridView ID="GridDetalle"
                    runat="server"
                    AutoGenerateColumns="true">
                </asp:GridView>
            </div>
            <div class="col-md-6">
                <asp:Button ID="BtnAgregar" runat="server" Text="Agregar linea" OnClick="BtnAgregar_Click" />
                <asp:Button ID="BtnQuitar" runat="server" Text="Quitar linea" />
             </div>
        </div>

        <asp:Label ID="Label3" runat="server" Text="Total:"></asp:Label><asp:TextBox ID="TxtTotal" runat="server"></asp:TextBox>
    </div>
    <p></p>
    <asp:Button ID="BtnGrabar" runat="server" onclick="BtnGrabar_Click" Text="Guardar Factura"/>
</asp:Content>
