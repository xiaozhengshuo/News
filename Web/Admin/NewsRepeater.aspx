<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="NewsRepeater.aspx.cs" Inherits="Web.Admin.NewsRepeater" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div _designerregion="0">
        排序方式：<asp:Button ID="btnTitleSort" runat="server" Text="按标题升序" OnClick="btnTitleSort_Click1" />
        <asp:Button ID="btnPubDateSort" runat="server" Text="按日期升序" OnClick="btnPubDateSort_Click1" />
    <asp:HiddenField ID="hfSortField" runat="server" Value="Id" />
    <asp:HiddenField ID="hfDirection" runat="server" Value="DESC" />
        <br />
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetNewsById" TypeName="NewsBLL.NewsManager">
        </asp:ObjectDataSource>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
                <ItemTemplate>
                <ul id="content_ul1">
                    <li class="li0"><a href="EditNews.aspx?Id=<%#Eval("Id") %>"><%#Eval("Title") %></a></li>
                    <li class="li1"><%#Eval("Author") %></li>
                    <li class="li2"><%#Eval("PubDate") %></li>
                    <li class="li3"><%#Eval("Clicks") %></li>
                    <li> <%#Eval("NewsCategory.Name") %></li>
                </ul>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <ul id="content_ul2">
                    <li class="li0"><a href="EditNews.aspx?Id=<%#Eval("Id") %>"><%#Eval("Title") %></a> </li>
                    <li class="li1"<%#Eval("Author") %>></li>
                    <li class="li2"<%#Eval("PubDate") %>></li>
                    <li class="li3"<%#Eval("Clicks") %>></li>
                    <li><%#Eval("NewsCategory.Name") %></li>
                </ul>
            </AlternatingItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
