<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.master" AutoEventWireup="true" CodeBehind="AgregarInvoiceLine.aspx.cs" Inherits="WebForms.Site.Ventas.AgregarInvoiceLine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
    <asp:Button ID="ButtonAdd" runat="server" Text="Agregar Item" onclick="ButtonAdd_Click" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
    <div class="container">
        <%--<asp:DropDownList ID="DropDownTracks" runat="server"></asp:DropDownList>--%>
        <div style="overflow-y: scroll; max-height: 200px;">
            <asp:RadioButtonList name="RadioButtonTracks" ID="RadioButtonTracks" runat="server"></asp:RadioButtonList>
        </div>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Precio"></asp:Label><asp:TextBox ID="TxtPrecio" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Cantidad"></asp:Label><asp:TextBox ID="TxtCantidad" runat="server"></asp:TextBox>
    </div>

    <script type="text/javascript">
        var radiobuttonlist = document.getElementById('<%=RadioButtonTracks.ClientID %>');

        var radiobuttons = radiobuttonlist.getElementsByTagName('input');

        

        for (var i = 0; i < radiobuttons.length; i++) {
           radiobuttons[i].addEventListener('change', function () {
                if (this.checked) {
                   
                    var span = this.parentNode;
                    var precio = span.getAttribute('data-precio');
                    document.getElementById('<%=TxtPrecio.ClientID %>').value = precio;
                }
            });
        }            
    </script>

</asp:Content>
