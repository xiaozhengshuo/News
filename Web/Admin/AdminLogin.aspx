<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Web.Admin.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/NewsPage.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="login_div">
        <table>
            <tr>
                <td class="auto-style1">
                    用户名：</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
                    <asp:Label ID="lblwangji" runat="server" ForeColor="#6666FF" Text="忘记密码？"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    密码：</td>
                <td>
                    <asp:TextBox ID="txtLoginPwd" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:Button ID="btnAddUser1" runat="server" BorderStyle="None" ForeColor="#6666FF" OnClick="btnAddUser1_Click" Text="新用户注册" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="content_center">
                    <asp:Button ID="btnLogin" runat="server" Text="登录" onclick="btnLogin_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
