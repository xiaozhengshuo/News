<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Web.Admin.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/NewsPage.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            height: 106px;
            margin-top: 74px;
        }
        .auto-style3 {
            height: 39px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="adduser">
        <table class="auto-style2">
            <tr>
                <td class="auto-style1">
                    用户名：</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    密码：</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtLoginPwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    真实姓名：</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtRealName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    住址：</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    电话</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    邮箱</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="content_center">
                    <asp:Button ID="btnAdd" runat="server" Text="注册" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnQuit" runat="server" OnClick="btnQuit_Click" Text="返回登陆" Width="78px" />
                </td>
            </tr>
        </table>
    </div>
         </form>
        </body>
   

</html>

