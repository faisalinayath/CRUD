<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication4.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        td, th {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 8px;
        }

        tr:nth-child(even) {
            background-color: #dddddd;
        }
    </style>
</head>
<body>
    <form runat="server" >
        <table>
            <tr>
                <th>Customer ID</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Email</th>
                <th>Phone</th>
                <th>Action</th>
            </tr>
            <asp:Repeater ID="myRepeater" runat="server" OnItemCommand="myRepeater_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("CustomerID") %></td>
                        <td><%# Eval("FirstName") %></td>
                        <td><%# Eval("LastName") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("Phone") %></td>
                        <td>

   <!--Don't forget to add the OnItemCommand attribute to the Repeater control and set it to the name of the method that handles
       the ItemCommand event, like this:-->


                            <asp:LinkButton runat="server" id="edit_button" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("CustomerID") %>' />
                           <asp:LinkButton runat="server" id="delete_button" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("CustomerID") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
