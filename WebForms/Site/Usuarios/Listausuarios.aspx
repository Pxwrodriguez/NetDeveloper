<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.master" AutoEventWireup="true" CodeBehind="Listausuarios.aspx.cs" Inherits="WebForms.Site.Usuarios.Listausuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
    <asp:GridView ID="GridViewUsuarios" 
        CssClass="table table-striped table-bordered" 
        AutoGenerateColumns="true"
        runat="server">    
    </asp:GridView>

</asp:Content>
