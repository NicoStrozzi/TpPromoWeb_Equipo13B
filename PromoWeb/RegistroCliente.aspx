<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind="RegistroCliente.aspx.cs" Inherits="PromoWeb.RegistroCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ErrorMessage="Ingresá DNI"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ControlToValidate="txtDni" runat="server" ErrorMessage="DNI Inavlido"></asp:RegularExpressionValidator>

    <asp:Button ID="btnBuscar" runat="server" Text="Buscar"/>

    <asp:TextBox ID="txtNombre" runat="server" />
<asp:RequiredFieldValidator ControlToValidate="txtNombre" runat="server" ErrorMessage="Requerido" />
<asp:TextBox ID="txtApellido" runat="server" />
<asp:RequiredFieldValidator ControlToValidate="txtApellido" runat="server" ErrorMessage="Requerido" />
<asp:TextBox ID="txtEmail" runat="server" />
<asp:RegularExpressionValidator ControlToValidate="txtEmail" runat="server"
    ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Email inválido" />

<!-- Dirección, Ciudad, CP con RequiredFieldValidator -->
<asp:CheckBox ID="chkTyC" runat="server" Text="Acepto términos" />
<asp:CustomValidator ID="valTyC" runat="server" ErrorMessage="Aceptá T&C" OnServerValidate="valTyC_ServerValidate" />

<asp:Button ID="btnParticipar" runat="server" Text="¡Participar!" OnClick="btnParticipar_Click" />
<asp:ValidationSummary runat="server" />
<asp:Label ID="lblError" runat="server" ForeColor="Red" />

</body>
</html>
