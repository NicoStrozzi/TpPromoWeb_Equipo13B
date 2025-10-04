<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RespuestaCodigo.aspx.cs" Inherits="PromoWeb.RespuestaCodigo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>Respuesta..</h1>
    </div>
    <div>
        <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
    </div>
    <div> 
        <asp:Button ID="btnVolverIngresar" runat="server" Text="Volver a ingresar" 
            CssClass="btn btn-primary"
            OnClick="btnVolverIngresar_Click"     
            />

    </div>

</asp:Content>
