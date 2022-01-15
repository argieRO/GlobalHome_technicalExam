<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="GlobalHome_technicalExam.SalesHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
            <asp:DropDownList ID="cbUsers" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="cbUsers_SelectedIndexChanged" ></asp:DropDownList>

            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAlluser" TypeName="GlobalHome_technicalExam.Models.SalesRepository"></asp:ObjectDataSource>

            <br />

            <asp:Textbox ID="tbProjectname" placeholder="Project Name" runat="server"></asp:Textbox>
            <br />


            <asp:Button ID="btAddProject" runat="server" Text="Add Project" Width="200px" BorderStyle="None" Height="60px" Font-Names="SF Pro Display" Font-Size="14pt"  OnClick="btAddProject_Click" BackColor="#99FF33" BorderColor="#CC00CC"/>
              <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" >
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="projectname" HeaderText="projectname" SortExpression="projectname" />
                    <asp:BoundField DataField="projectstatus" HeaderText="projectstatus" SortExpression="projectstatus" />
                    <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
                </Columns>
            </asp:GridView>

            <asp:ObjectDataSource ID="SourceByUser" runat="server" SelectMethod="GetProjectsByUser" TypeName="GlobalHome_technicalExam.Models.SalesRepository">
                <SelectParameters>
                    <asp:ControlParameter ControlID="cbUsers" Name="inUserID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAllProjects" TypeName="GlobalHome_technicalExam.Models.SalesRepository"></asp:ObjectDataSource>

            <br />
        </div>
    </form>
</body>
</html>
