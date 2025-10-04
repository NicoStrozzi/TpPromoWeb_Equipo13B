<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RespuestaCodigo.aspx.cs" Inherits="PromoWeb.RespuestaCodigo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <div class="row">
            <div class="col-md-8 offset-md-2 text-center">
                <h1 class="mb-4">Respuesta</h1>
                
                <div class="alert alert-danger" role="alert">
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </div>

                <asp:Button 
                    ID="btnVolverIngresar" 
                    runat="server" 
                    Text="Volver a ingresar" 
                    CssClass="btn btn-primary px-4 py-2"
                    OnClick="btnVolverIngresar_Click" />
            </div>
        </div>
    </div>

</asp:Content>
