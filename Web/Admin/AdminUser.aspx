<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminUser.aspx.cs" Inherits="Web.Admin.AdminUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="NewsModels.User" DeleteMethod="DeletUser" SelectMethod="SelectUser" TypeName="NewsBLL.UserManager" UpdateMethod="UpdateUser"></asp:ObjectDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="编号" SortExpression="Id" />
            <asp:BoundField DataField="LoginName" HeaderText="登录名" SortExpression="LoginName" />
            <asp:BoundField DataField="LoginPwd" HeaderText="登录密码" SortExpression="LoginPwd" />
            <asp:BoundField DataField="RealName" HeaderText="真实姓名" SortExpression="RealName" />
            <asp:BoundField DataField="Address" HeaderText="住址" SortExpression="Address" />
            <asp:BoundField DataField="Phone" HeaderText="电话" SortExpression="Phone" />
            <asp:BoundField DataField="Email" HeaderText="邮箱" SortExpression="Email" />
            <asp:BoundField DataField="Role" HeaderText="角色" SortExpression="Role" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" SortExpression="Id" />
        </Columns>
    </asp:GridView>
</asp:Content>
