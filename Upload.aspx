<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="PngToReactionGif.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Upload.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="imgDiv" class="image-container" runat="server">
        </div>
        <div>
            <asp:FileUpload ID="PngUpload" runat="server" CssClass="file-upload" />
            <asp:TextBox ID="NameTB" runat="server" placeholder="Enter gif name" ></asp:TextBox>
            <asp:Button ID="ConvertButton" runat="server" Text="CONVERT" OnClick="ConvertButton_Click" />
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
