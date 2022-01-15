<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdduserForm.aspx.cs" Inherits="GlobalHome_technicalExam.AdduserForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:Textbox ID="tbUsername" placeholder="User Name" runat="server"></asp:Textbox>
            <asp:DropDownList ID="cbUserlevel" runat="server">
                <asp:ListItem>Super user</asp:ListItem>
                <asp:ListItem>Sales lead</asp:ListItem>
                <asp:ListItem>Sales representative</asp:ListItem>
            </asp:DropDownList>


            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Userlevel" HeaderText="Userlevel" SortExpression="Userlevel" />
                </Columns>
            </asp:GridView>

            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAlluser" TypeName="GlobalHome_technicalExam.Models.SalesRepository"></asp:ObjectDataSource>


            <br />

            <br />

            <asp:Button ID="btAddUser" runat="server" Text="Add User" Width="200px" BorderStyle="None" Height="60px" Font-Names="SF Pro Display" Font-Size="14pt"  OnClick="btAddUser_Click" BackColor="#99FF33" BorderColor="#CC00CC"/>

        </div>
    </form>
</body>
</html>
