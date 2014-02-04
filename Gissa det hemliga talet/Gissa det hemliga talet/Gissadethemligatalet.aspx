<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gissadethemligatalet.aspx.cs" Inherits="Gissa_det_hemliga_talet.Gissa_det_hemliga_talet" ViewStateMode="Disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Css/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" defaultfocus="Guess">
    <div>

    <div id="lefty"></div>
    <h1>Gissa det hemliga talet</h1>
    <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Vänligen åtgärda följande fel:" runat="server" CssClass="Red" />
    <br />
    <div id="filler"></div>
    <asp:Label ID="Label1" AssociatedControlID="Guess" runat="server" Text="Ange ett tal mellan 1-100"></asp:Label>
    <br />   
    <asp:TextBox ID="Guess" runat="server"></asp:TextBox>    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Guess" runat="server" Text="*" ErrorMessage="Ange ett tal mellan 1-100" Display="Dynamic" CssClass="Red"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" ControlToValidate="Guess" runat="server" Text="*" ErrorMessage="Ange ett tal mellan 1-100" Display="Dynamic" MaximumValue="100" MinimumValue="1" CssClass="Red"></asp:RangeValidator>
    <asp:Button ID="Send" runat="server" Text="Skicka Gissning" OnClick="Button1_Click" />
    <br />
    <br />
    <asp:Button ID="Randomize" runat="server" Text="Slumpa ett nytt tal" Visible="false" />
    </div>
    </form>
</body>
</html>
