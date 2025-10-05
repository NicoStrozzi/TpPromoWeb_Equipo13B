<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="PromoWeb.Exito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8 text-center">

                <!-- Mensaje de éxito -->
                <div class="alert alert-success p-4 shadow-sm" role="alert">
                    <h2 class="mb-3">¡Registro exitoso!</h2>
                    <p class="mb-0 alert-success">Tu participación fue registrada correctamente.</p>
                    <p class="bi bi-envelope-check-fill mb-0 alert-success"> Enviamos un mensaje a tu correo con la confirmacion!!.</p>
                </div>

                <!-- Botón para volver al inicio -->
                <asp:Button
                    ID="btnVolverHome"
                    runat="server"
                    Text="Volver al inicio"
                    CssClass="btn btn-primary px-4 py-2 mt-3"
                    OnClick="btnVolverHome_Click" />
            </div>
        </div>
    </div>
</asp:Content>
