<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.master" AutoEventWireup="true" CodeBehind="AgregarInvoiceLine.aspx.cs" Inherits="WebForms.Site.Ventas.AgregarInvoiceLine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
    <asp:Button ID="ButtonAdd" runat="server" Text="Agregar Item" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
    <div class="container">
        <%--<asp:DropDownList ID="DropDownTracks" runat="server"></asp:DropDownList>--%>
        <asp:RadioButtonList ID="RadioButtonTracks" runat="server"></asp:RadioButtonList>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Precio"></asp:Label><asp:TextBox ID="TxtPrecio" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Cantidad"></asp:Label><asp:TextBox ID="TxtCantidad" runat="server"></asp:TextBox>
    </div>
</asp:Content>
