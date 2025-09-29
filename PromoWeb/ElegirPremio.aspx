<%@ Page Language="C#" AutoEventWireup="true" MasterPageFlie="~/Master.Master" CodeBehind="ElegirPremio.aspx.cs" Inherits="PromoWeb.ElegirPremio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Elegir Premio</title>
</head>
<body>
    
        <div>
            <asp:Repeater ID="repPremios" runat="server" OnItemCommand="repPremios_ItemCommand"></asp:Repeater>
            <asp:Button ID="btnElegir" runat="server" Text="Elegir" />
        </div>
   
</body>
</html>
