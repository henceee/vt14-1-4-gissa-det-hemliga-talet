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
    <asp:rangevalidator id="rangevalidator1" controltovalidate="guess" runat="server" text="*" errormessage="Ange ett tal mellan 1-100" display="dynamic" maximumvalue="100" minimumvalue="1" type="integer" cssclass="red"></asp:rangevalidator>
    <asp:Button ID="Send" runat="server" Text="Skicka Gissning" OnClick="Button1_Click" />
    
    <asp:PlaceHolder ID="Result" runat="server" Visible="false">
        <asp:Panel ID="guesses" runat="server">
        <p><asp:Literal ID="PrevguessLiteral" runat="server">{0}</asp:Literal>  </p>
        </asp:Panel>       
        <p><asp:Literal ID="AccuracyLiteral" runat="server">{0}{1}</asp:Literal>  </p>    
       
    </asp:PlaceHolder>    
    <asp:Button ID="Randomize" runat="server" Text="Slumpa ett nytt tal" Visible="false" OnClick="Randomize_Click" />
    </div>
    </form>
</body>
</html>
