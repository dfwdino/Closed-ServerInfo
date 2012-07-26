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
      
        <asp:ScriptManager ID="SMGetInfo" runat="server"></asp:ScriptManager>
        
        <asp:UpdatePanel ID="UPGetInfo" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblSeverName" runat="server" Text="Server Name:"></asp:Label>
                <asp:TextBox ID="txtServerName" runat="server"></asp:TextBox>
                <asp:Button ID="btnGetServerInfo" runat="server" OnClick="btnGetServerInfo_Click" Text="Get Info" />
                <p id="testp" runat="server"></p>
        </ContentTemplate>
        </asp:UpdatePanel>
    
        <asp:UpdateProgress ID="UPrGetInfo" DisplayAfter="0" runat="server"> 
            <ProgressTemplate> <div style="position: relative; top: 30%;">Processing ... </div> </ProgressTemplate> 
        </asp:UpdateProgress> 
    
    </div>
    </form>
</body>
</html>
