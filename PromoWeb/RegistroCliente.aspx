<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind="RegistroCliente.aspx.cs" Inherits="PromoWeb.RegistroCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="col-4"></div>
    <div class="row g-3">
        <h2 class="d-flex h-2">Ingresa tus datos</h2>
        <br />

        <div class="col-4">
            <label for="txtDNI" class="form-label">DNI</label>
            <asp:TextBox CssClass="form-control" placeholder="DNI" runat="server" ID="txtDNI" />

        </div>

        <div class="col-12">
            <asp:Button runat="server" Text="Buscar" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click"/>
            <asp:Label ID="lblEstadoCliente" runat="server" CssClass="text-info" Visible="false" />

        </div>

        <br />

        <div class="col-4">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox CssClass="form-control" placeholder="Nombre" runat="server" ID="txtNombre" />
        </div>
        <div class="col-4">
            <label for="txtApellido" class="form-label">Apellido</label>
            <asp:TextBox CssClass="form-control" placeholder="Apellido" runat="server" ID="txtApellido" />
        </div>

        <div class="col-8">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox type="email" CssClass="form-control" ID="txtEmail" placeholder="email@ejemplo.com" runat="server" />
        </div>

        <div class="col-8">
            <label for="txtDireccion" class="label">Dirección</label>
            <asp:TextBox runat="server" type="text" CssClass="form-control" ID="txtDireccion" placeholder="Mi Calle 1234" />
        </div>
        <div class="col-8">
            <table>
                <tr>
                    <td class="col-6">
                        <div>
                            <label for="txtCiudad" class="label">Ciudad</label>
                            <asp:TextBox runat="server" type="text" CssClass="form-control" ID="txtCiudad" />
                        </div>

                    </td>
                    <td class="col-2">
                        <div>
                            <label for="txtCP" class="label">CP</label>
                            <asp:TextBox runat="server" type="text" CssClass="form-control" ID="txtCP" />
                        </div>
                    </td>

                </tr>
            </table>
        </div>

        <br />

        <div class="col-12">
            <asp:Button runat="server" Text="Participar" ID="btnParticipar" CssClass="btn btn-primary" OnClick="btnParticipar_Click"/>
        </div>
        <div class="col-12">
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false" />
        </div>


    </div>
    <div class="col-2"></div>
</asp:Content>