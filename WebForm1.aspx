<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="實驗室管理.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LaboratoryborrowConnectionString %>" SelectCommand="SELECT * FROM [bookbuyers]"></asp:SqlDataSource>
        </div>
        <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" CellPadding="4" DataKeyNames="book_ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="50px" Width="125px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <EditRowStyle BackColor="#999999" />
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
            <Fields>
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="book_ID" HeaderText="book_ID" ReadOnly="True" SortExpression="book_ID" />
                <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
                <asp:BoundField DataField="publicsh" HeaderText="publicsh" SortExpression="publicsh" />
                <asp:BoundField DataField="book_borrow_ID" HeaderText="book_borrow_ID" SortExpression="book_borrow_ID" />
                <asp:BoundField DataField="user_ID" HeaderText="user_ID" SortExpression="user_ID" />
            </Fields>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        </asp:DetailsView>
    </form>
    <a href="https://localhost:44384/Books">返回</a>
</body>
</html>
