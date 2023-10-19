<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.master" AutoEventWireup="true" CodeBehind="VotacionAlbum.aspx.cs" Inherits="WebForms.Site.Albums.VotacionAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
     <p>For Those About To Rock We Salute You</p>
     <select id="ddlAlbunes"></select>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
    <div>
        <h2>Votacion por albumunes</h2>       
        <p>Valoracion actual: <span id="rating">0</span></p>
        <div class="progress">
             <div class="progress-bar" role="progressbar" style="width: 0%;" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" id="progressBar"></div>
        </div>
        <button id="btnUpVote" class="btn">Votar +1</button>
        <button id="btnDownVote" class="btn">Votar -1</button>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            cargaralbunes()
            $("#btnUpVote").click(function () {
                event.preventDefault();
                votar(1);
            });
            $("#btnDownVote").click(function () {
                event.preventDefault();
                votar(-1)
            });
        });
      
        function cargaralbunes() {
            $.ajax({               
                type: "POST",
                url: "VotacionAlbum.aspx/ObtenerAlbunes",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var ddlCategories = document.getElementById("ddlAlbunes");
                    
                    ddlCategories.innerHTML = "";


                    for (var i = 0; i < response.d.length; i++) {
                        var option = document.createElement("option");
                        option.text = response.d[i].Title;  
                        option.value = response.d[i].Albumid;  
                        ddlCategories.add(option);
                    }
                },
                error: function (error) {
                    console.log("Error: " + error.responseText);
                }
            });
        }

        function votar(value) {
            var idalbum = $("#ddlAlbunes").val();
            $.ajax({
                type: "POST",
                url: "VotacionAlbum.aspx/ActualizarVoto",
                data: JSON.stringify({ idalbum:idalbum, value: value }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d) {
                        var valoractual = parseInt($("#rating").text());
                        var nuevovalor = valoractual + value;
                        $("#rating").text(nuevovalor);
                        actualizarProgressBar(nuevovalor);
                    }
                },
                error: function (response) {
                    console.log(response);
                }
            });
        }

        function actualizarProgressBar(rating) {
            var max = 100;
            var porcent = (rating / max) * 100;
            $("#progressBar").css("width", porcent + "%");
            $("#progressBar").atrr("aria-valuenow", rating );
        }

    </script>
</asp:Content>

