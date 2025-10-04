<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PromoWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8 text-center">
                <div class="alert alert-primary p-4 shadow-sm" role="alert">
                    <h1>¡Bienvenido!</h1>
                    <p>Participá ingresando tu código de voucher.</p>
                </div>

                <!-- Link a la siguiente
                <asp:HyperLink ID="lnkCodigo" runat="server"
                NavigateUrl="~/CodigoVoucher.aspx"
                CssClass="btn btn-primary">Ingresar código</asp:HyperLink>-->

                <asp:Button
                    ID="btnCodigo"
                    runat="server"
                    Text="Ingresar código"
                    CssClass="btn btn-primary"
                    OnClick="btnCodigo_Click"
                    CausesValidation="false" />
            </div>
        </div>
    </div>
</asp:Content>

