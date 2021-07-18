<%@ Page Title="修改|添加文章" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EditNews.aspx.cs" Inherits="Web.Admin.EditNews" %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language = "javascript" type = "text/javascript" src = "../My97DatePicker/WdatePicker.js"></script>
         <script language="javascript" type = "text/javascript">
             var oEditer;
             function CustomValidate(source, arguments) {
                 var value = oEditer.GetXHTML(true);
                 if (value == "") {
                     arguments.IsValid = false;
                 }
                 else {
                     arguments.IsValid = true;
                 }
             }
             function FCKeditor_OnComplete(editorInstance) {
                 oEditer = editorInstance;
             }
         </script>
    <asp:DetailsView ID="dvNews" runat="server" AutoGenerateRows="False" 
        DataSourceID="odsNews" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="Id" HeaderText="编号" 
                SortExpression="Id" />
            <asp:BoundField DataField="Title" HeaderText="标题" 
                SortExpression="Title" />
            <asp:BoundField DataField="Author" HeaderText="作者" SortExpression="Author" />
            <asp:BoundField DataField="PubDate" HeaderText="时间" SortExpression="PubDate" />
            <asp:BoundField DataField="Contents" HeaderText="内容" SortExpression="Contents" >
            <ControlStyle Font-Bold="True" Font-Italic="False" Font-Size="XX-Large" />
            </asp:BoundField>
            <asp:ImageField DataImageUrlField="Image" DataImageUrlFormatString="~\Images\{0}" HeaderText="图片">
            </asp:ImageField>
            <asp:BoundField DataField="Clicks" HeaderText="点击量" SortExpression="Clicks" />
            <asp:BoundField DataField="NewsCategoryId" HeaderText="类别" SortExpression="NewsCategoryId" />
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:DetailsView>
    <asp:ObjectDataSource ID="OdsNewsCategory" runat="server" 
        SelectMethod="GetNewsCategoryById" TypeName="NewsBLL.NewsCategoryManager">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="Name" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsNews" runat="server" SelectMethod="GetNewsById" 
        TypeName="NewsBLL.NewsManager" DataObjectTypeName="NewsModels.News" 
        DeleteMethod="AddNews" UpdateMethod="ModifyNews">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="Id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
