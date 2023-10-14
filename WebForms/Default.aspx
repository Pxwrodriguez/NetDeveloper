<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>TIENDA DE MUSICA</h1>
    <p></p>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="img-box">
                    <div>
                        <img src="Images\image2.png" alt="" class="" />
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="detail-box">
                    <div>
                        <h1>Artistas<br>
                            Albumunes<br>
                            Musica
                        </h1>
                        <p>
                            ...y mas
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid footer_section">
        <div class="row">
            <div class="col-md-6">
                <h2>Inicio</h2>
                <p>
                    Inicie sesión en el sistema con su usuario para acceder a los modulos.
                </p>
                <p>
                    <a class="btn btn-warning" role="button" data-bs-toggle="button" href="Account/Login.aspx">Ingresar &raquo;</a>
                </p>
            </div>
            <div class="col-md-6">
                <h2 class="text-danger">Informacion importante</h2>
                <p>
                    Tienda de musica
                </p>
                <p>
                    <a class="btn btn-warning" role="button" data-bs-toggle="button" href="https://www.mitiendademusica.com.pe">Ir a la web &raquo;</a>
                </p>
            </div>
        </div>

    </div>

</asp:Content>
