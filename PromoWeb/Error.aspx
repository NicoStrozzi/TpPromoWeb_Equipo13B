<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind="Error.aspx.cs" Inherits="PromoWeb.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8 text-center">

                <!-- Mensaje de éxito -->
                <div class="alert alert-danger p-4 shadow-sm" role="alert">
                    <h2 class="mb-3">¡Ha ocurrido un error!</h2>
                    <p class="mb-0">Vuelva a intentarlo nuevamente.</p>
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
