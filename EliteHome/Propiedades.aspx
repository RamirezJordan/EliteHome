<%@ Page Language="vb" AutoEventWireup="false" CodeFile="Propiedades.aspx.vb" Inherits="Propiedades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lista de Propiedades</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>

</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="container-fluid">
        <a class="navbar-brand" href="Home.aspx">EliteHomes</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav ms-auto">
                <li class="nav-item">
                    <a class="nav-link" href="Home.aspx">Home</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="About.aspx">About Us</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Contact.aspx">Contact</a>
                </li>
                <% If Session("UsuarioRol") = "Administrador" Then %>
                <li class="nav-item">
                    <a class="nav-link" href="Admin.aspx">Administrador</a>
                </li>
                <% End If %>
                <% If Session("UsuarioId") Is Nothing Then %>
                <li class="nav-item">
                    <a class="nav-link" href="Login.aspx">Iniciar Sesión</a>
                </li>
                <% Else %>
                <li class="nav-item">
                    <a class="nav-link" href="Logout.aspx">Cerrar Sesión</a>
                </li>
                <% End If %>
            </ul>
        </div>
    </div>
</nav>
    <div class"container d-flex flex-wrap justify-content-center">
    <h1 class="text-center my-4 w-100">Lista de Propiedades</h1>
    <div class="row justify-content-center">
        <%For Each propiedad As EliteHome.EliteHomes.Models.Propiedad In PropiedadesList %>
            <div class="col-lg-3 col-md-6 col-sm-12 mb-4">
                <div class="card">
                    <img src="<%= propiedad.imagen %>" class="card-img-top" alt="Imagen de la propiedad" />
                    <h3 class="card-title"><%= propiedad.Descripcion %></h3>
                    <p class="card-text"><strong>Precio:</strong> <%= String.Format("{0:C}", propiedad.Precio) %></p>
                    <p class="card-text"><strong>Ubicación:</strong> <%= propiedad.Ubicacion %></p>
                    <button class="btn btn-primary btn-block" onclick="location.href='DetallesPropiedad.aspx?id=<%= propiedad.Id %>'">Más información</button>
                </div>
            </div>
        <% Next %>
    </div>
</div>
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
