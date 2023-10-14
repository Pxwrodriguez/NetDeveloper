<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusquedaAlbum.aspx.cs" Inherits="WebForms.Site.Albums.BusquedaAlbum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Busqueda en tiempo real</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="txtSearch">Buscar:</label>
            <input type="text" id="txtSearch" />
            <div id="searchResults"></div>
        </div>
    </form>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtSearch").on("input", function () {
                var searchtext = $(this).val();
                if (searchtext.length >= 3) {
                    ejecutarbusqueda(searchtext);
                } else {
                    $("#searchResults").empty();
                }
            });
        });

        function ejecutarbusqueda(searchtext) {
            $.ajax({
                type: "POST",
                url: "BusquedaAlbum.aspx/BuscarTitulo",
                data: JSON.stringify({ searchtext: searchtext }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    mostrarresultados(data.d);
                },
                error: function (xhr, status, error) {
                    console.error(error);
                }
            });
        }

        function mostrarresultados(results) {
            var $searchResults = $("#searchResults");
            $searchResults.empty();

            if (results.length > 0) {
                var $ul = $("<ul>");
                $.each(results, function (index, item) {
                    var $li = $("<li>").text(item);
                    $ul.append($li);
                });
                $searchResults.append($ul);
            } else {
                $searchResults.text("No se encontraron resultados");
            }
        }
    </script>
</body>
</html>
