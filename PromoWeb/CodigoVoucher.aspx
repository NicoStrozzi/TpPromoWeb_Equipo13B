<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind="CodigoVoucher.aspx.cs" Inherits="PromoWeb.CodigoVoucher" %>
<asp:Content ID="HeadBlock" ContentPlaceHolderID="HeadContent" runat="server">
  <title>Ingresa ódigo| Promo</title>
</asp:Content>

<asp:Content ID="MainBlock" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row justify-content-center">
    <div class="col-12 col-sm-10 col-md-8 col-lg-6">
      <div class="card shadow-sm">
        <div class="card-body">
          <h2 class="h4 mb-3">Ingresá el código de tu voucher</h2>

          <asp:ValidationSummary ID="valSummary" runat="server"
              CssClass="alert alert-danger" ShowSummary="true" HeaderText="Corregí estos campos:" />

          <div class="mb-3">
            <label for="txtVoucher" class="form-label">Código</label>
            <asp:TextBox ID="txtVoucher" runat="server" MaxLength="40" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvVoucher" runat="server"
                ControlToValidate="txtVoucher" ErrorMessage="El código es requerido."
                Display="Dynamic" CssClass="text-danger" />
          </div>

          <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente"
              CssClass="btn btn-primary w-100" OnClick="btnSiguiente_Click" />
        </div>
      </div>
    </div>
  </div>
</asp:Content>