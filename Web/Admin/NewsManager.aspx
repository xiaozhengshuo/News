<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="NewsManager.aspx.cs" Inherits="Web.Admin.NewsManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language = "javascript" type = "text/javascript" src = "../My97DatePicker/WdatePicker.js"></script>
    <table>
        <tr>
            <th rowspan="3">
                查询方式：</th>
            <td>
                类别</td>
            <td colspan="4">
                <asp:DropDownList ID="ddlNewsCategorySearch" runat="server" 
                    DataSourceID="odsNewsCategories" DataTextField="Name" DataValueField="Id" 
                    ondatabound="ddlNewsCategorySearch_DataBound">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 23px">
                标题</td>
            <td style="height: 23px">
                <asp:TextBox ID="txtTitleSearch" runat="server"></asp:TextBox>
            </td>
            <td style="height: 23px">
                作者</td>
            <td style="height: 23px">
                <asp:TextBox ID="txtAuthorSearch" runat="server"></asp:TextBox>
            </td>
            <td style="height: 23px">
            </td>
        </tr>
        <tr>
            <td>
                日期</td>

            <td>
                <asp:TextBox ID="txtStartTime" runat="server" CssClass="Wdate"
                onClick = "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
            </td>

            <td>
                ——</td>
            <td>
                <asp:TextBox ID="txtEndTime" runat="server" CssClass="Wdate"
                onClick = "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <th>

                排序方式：</th>
            <td colspan="2">
                <asp:Button ID="btnTitleSort" runat="server" Text="按标题升序" 
                    onclick="btnTitleSort_Click" />
&nbsp;|
                <asp:Button ID="btnPubDateSort" runat="server" Text="按日期升序" 
                    onclick="btnPubDateSort_Click" />
            </td>
            <td>
    <asp:HiddenField ID="hfSortField" runat="server" Value="Id" />
            </td>
            <td>
    <asp:HiddenField ID="hfDirection" runat="server" Value="DESC" />
            </td>
            <td>
    <asp:HiddenField ID="hfSearch" runat="server" Value="1=1" />
            </td>
        </tr>
    </table>
    <div id="admin_div">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateColumns="False" DataSourceID="odsNews" DataKeyNames="Id" AllowPaging="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" 
                    Visible="False" />
                <asp:BoundField DataField="Title" HeaderText="标题" SortExpression="Title" />
                <asp:BoundField DataField="Author" HeaderText="作者" 
                    SortExpression="Author" />
                <asp:BoundField DataField="PubDate" HeaderText="日期" 
                    SortExpression="PubDate" />
                <asp:BoundField DataField="Clicks" HeaderText="浏览次数" 
                    SortExpression="Clicks" />
                <asp:TemplateField HeaderText="类别" SortExpression="NewsCategory">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("NewsCategory.Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ImageField DataImageUrlField="Image" DataImageUrlFormatString="~\Images\{0}" HeaderText="图片">
                    <ControlStyle Height="50px" Width="50px" />
                </asp:ImageField>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:HyperLinkField DataNavigateUrlFields="Id" 
                    DataNavigateUrlFormatString="EditNews.aspx?Id={0}" Text="详细" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    <asp:ObjectDataSource ID="odsNews" runat="server" 
        SelectMethod="GetNewsPartFieldsByConditions" TypeName="NewsBLL.NewsManager" 
            DataObjectTypeName="NewsModels.News" DeleteMethod="DeleteNews">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfSearch" Name="conditions" 
                PropertyName="Value" Type="String" />
            <asp:ControlParameter ControlID="hfSortField" Name="sortFieild" 
                PropertyName="Value" Type="String" />
            <asp:ControlParameter ControlID="hfDirection" Name="direcion" 
                PropertyName="Value" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsNewsCategories" runat="server" 
            SelectMethod="GetNewsCategories" TypeName="NewsBLL.NewsCategoryManager">
        </asp:ObjectDataSource>
        ?</div>
</asp:Content>
