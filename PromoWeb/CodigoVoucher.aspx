<%@ Page Title="Ingresa Codigo | Promo" Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind="CodigoVoucher.aspx.cs" Inherits="PromoWeb.CodigoVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8 text-center">
                <div class="alert alert-success p-4 shadow-sm" role="alert">
                    <h2>Ingresá tu código</h2>
                </div>
                <div>
                    <asp:TextBox ID="txtVoucher" runat="server" MaxLength="24" CssClass="form-control" />
                </div>

                <asp:Button ID="btnSiguiente" runat="server" Text="Validar y continuar"
                    CssClass="btn btn-primary px-4 py-2 mt-3"
                    OnClick="btnSiguiente_Click" />
            </div>
        </div>
    </div>
</asp:Content>
