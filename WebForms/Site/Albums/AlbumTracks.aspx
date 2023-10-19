<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.master" AutoEventWireup="true" CodeBehind="AlbumTracks.aspx.cs" Inherits="WebForms.Site.Albums.AlbumTracks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
    <h1>Listado de albunes y tracks</h1>

    <asp:GridView ID="GridViewLista" 
        runat="server"
        AutoGenerateColumns="true"
        OnSelectedIndexChanged="GridViewLista_SelectedIndexChanged"
        AutoGenerateSelectButton="true"
        CssClass="table table-striped table-bordered"
        AllowPaging="true"
        PageSize="12"
        >
    </asp:GridView>




    <asp:GridView ID="GridViewAlbums" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Albumid" HeaderText="Id Album" />
            <asp:BoundField DataField="Title" HeaderText="Titulo" />
            <asp:TemplateField HeaderText="Tracks">
                <ItemTemplate>
                    <ul>
                        <asp:Repeater ID="RepeaterTrack" runat="server" DataSource='<%#Eval("Tracks") %>'>
                            <ItemTemplate>
                                <li><%#Eval("Name") %> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
