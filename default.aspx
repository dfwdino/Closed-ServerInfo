<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ServerInfo._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="#FF3300"></asp:Label>
    
        <br />
        <br />
        <asp:Label ID="lblSeverName" runat="server" Text="Server Name:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtServerName" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGetServerInfo" runat="server" 
            OnClick="btnGetServerInfo_Click" Text="Get Info" />
        <br />
        <br />
        <table id="ServerDataPlace" runat="server"></table>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
