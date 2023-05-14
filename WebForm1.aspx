<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication4.WebForm1" %>

<!DOCTYPE html>
<html>
<head>
    <title>My Form</title>
</head>
<body>
    <form runat="server">

        <div>
            <label for="txtFirstName">First Name:</label>
            <input type="text" id="txtFirstName" name="txtFirstName" />
        </div>
        <div>
            <label for="txtLastName">Last Name:</label>
            <input type="text" id="txtLastName" name="txtLastName" />
        </div>
        <div>
            <label for="txtEmail">Email:</label>
            <input type="email" id="txtEmail" name="txtEmail" />
        </div>
        <div>
            <label for="txtPhone">Phone:</label>
            <input type="text" id="txtPhone" name="txtPhone" />
        </div>
        <div>
            <input type="submit" value="Submit" runat="server" onserverclick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>