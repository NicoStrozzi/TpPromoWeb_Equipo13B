<%@ Page Title="Ingresa Codigo | Promo" Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind="CodigoVoucher.aspx.cs" Inherits="PromoWeb.CodigoVoucher" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Ingresá tu código</h2>

    <asp:TextBox ID="txtVoucher" runat="server" MaxLength="24" CssClass="form-control" />
    <br />

    <asp:Button ID="btnSiguiente" runat="server" Text="Validar y continuar"
        CssClass="btn btn-primary"
        OnClick="btnSiguiente_Click" />

    <br /><br />
    <asp:Label ID="lblError" runat="server" ForeColor="Red" />
</asp:Content>