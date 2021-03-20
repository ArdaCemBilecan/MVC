<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BasicCalculator.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
     
    </div>
    <asp:Panel ID="Panel1" runat="server" GroupingText="Hesap Makinesi"
            Width="280px">
            <table class="style1">
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="TextBox1" runat="server" Height="60px" Width="250px"
                            CssClass="kutu" AutoPostBack="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button16" runat="server" Height="60px" Text="C" Width="60px" OnClick="Button16_Click"  />
                    </td>
                    <td>
                        <asp:Button ID="Button10" runat="server" Height="60px" 
                            Text="/" Width="60px" OnClick="Button10_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button11" runat="server" Height="60px" 
                            Text="*" Width="60px" OnClick="Button11_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button12" runat="server" Height="60px" 
                            Text="-" Width="60px" OnClick="Button12_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button7" runat="server" Height="60px" 
                            Text="7" Width="60px" OnClick="Button7_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button8" runat="server" Height="60px" 
                            Text="8" Width="60px" OnClick="Button8_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button9" runat="server" Height="60px" 
                            Text="9" Width="60px" OnClick="Button9_Click" />
                    </td>
                    <td rowspan="2">
                        <asp:Button ID="Button13" runat="server" Height="120px" 
                            Text="+" Width="60px" OnClick="Button13_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button4" runat="server" Height="60px" 
                            Text="4" Width="60px" OnClick="Button4_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button5" runat="server" Height="60px" 
                            Text="5" Width="60px" OnClick="Button5_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button6" runat="server" Height="60px" 
                            Text="6" Width="60px" OnClick="Button6_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Height="60px" 
                            Text="1" Width="60px" OnClick="Button1_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Height="60px" 
                            Text="2" Width="60px" OnClick="Button2_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" Height="60px" 
                            Text="3" Width="60px" OnClick="Button3_Click" />
                    </td>
                    <td rowspan="2">
                        <asp:Button ID="Button14" runat="server" Height="120px"
                            Text="=" Width="60px" OnClick="Button14_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="Button15" runat="server" Height="60px" 
                            Text="0" Width="199px" OnClick="Button15_Click" />
                    </td>

                </tr>

                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button17" runat="server" Height="50px" 
                            Text="," Width="199px" OnClick="Button17_Click" />
                    </td>
                    </tr>
            </table>
        </asp:Panel>
     
    </form>
</body>
</html>
