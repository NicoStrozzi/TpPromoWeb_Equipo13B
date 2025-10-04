<%@ Page Title="PromoWeb — Inicio"
    Language="C#"
    MasterPageFile="~/Master.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="PromoWeb.Default" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center py-5">

        <h1 class="mb-3">PROMOWEB</h1>
        <p class="text-muted fw-bold fs-5">Ingresá código → Elegí premio → Confirmá</p>

        <asp:Button ID="btnCodigo" runat="server" Text="CANJEAR VOUCHER" CssClass="btn btn-primary btn-lg mb-5" OnClick="btnCodigo_Click" />

        <div class="row">
            <div class="col-6 col-md-4 mb-4">
                <i class="bi bi-smartwatch" style="font-size:2.2rem; color:blue;"></i>
                <p>Reloj</p>
            </div>
            <div class="col-6 col-md-4 mb-4">
                <i class="bi bi-headphones" style="font-size:2.2rem; color:deeppink;"></i>
                <p>Auriculares</p>
            </div>
            <div class="col-6 col-md-4 mb-4">
                <i class="bi bi-phone" style="font-size:2.2rem; color:mediumseagreen;"></i>
                <p>Smartphone</p>
            </div>
            <div class="col-6 col-md-4 mb-4">
                <i class="bi bi-laptop" style="font-size:2.2rem; color:purple;"></i>
                <p>Notebook</p>
            </div>
            <div class="col-6 col-md-4 mb-4">
                <i class="bi bi-camera" style="font-size:2.2rem; color:orange;"></i>
                <p>Cámara</p>
            </div>
            <div class="col-6 col-md-4 mb-4">
                <i class="bi bi-bag" style="font-size:2.2rem; color:green;"></i>
                <p>Mochila</p>
            </div>
        </div>
    </div>
</asp:Content>
