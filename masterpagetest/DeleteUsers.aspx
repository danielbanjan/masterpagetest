<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteUsers.aspx.cs" Inherits="DeleteUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
    Delete Users
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div style="width:100%">
        <div id="inputemail" style="width:30%;height:5%;padding-bottom:5px;padding-right:12px; float: left;" runat="server">Please Input Email</div>
        <div> 
            <asp:CheckBox id="checkbox1" runat="server" AutoPostBack="True" Text="Select All" TextAlign="Right" OnCheckedChanged="Check_Clicked"/>
        </div>
    </div>
    <div style="width:25%;padding-right:5px;float: left;">
        <asp:TextBox ID="TextBox1" placeholder="test@test.com" runat="server" style="max-width:300px" Width="300px" Height="100px" TextMode="MultiLine"></asp:TextBox>
    </div>
    <div style="width:5%;padding-right:5px;float: left;">
        <asp:Button runat="server" ID="btn" class ="button" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete?');" onclick="Button1_Click"/>
    </div>
    <div style="width:25%;float:left">
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" >
            <asp:ListItem Text="Argentina" Value="AR"></asp:ListItem>
            <asp:ListItem Text="Australia" Value="AU"></asp:ListItem>
            <asp:ListItem Text="Austria" Value="AT"></asp:ListItem>
            <asp:ListItem Text="Bangladesh" Value="BD"></asp:ListItem>
            <asp:ListItem Text="Brazil" Value="BR"></asp:ListItem>
            <asp:ListItem Text="Canada" Value="CA"></asp:ListItem>
            <asp:ListItem Text="Chile" Value="CL"></asp:ListItem>
            <asp:ListItem Text="Colombia" Value="CO"></asp:ListItem>
            <asp:ListItem Text="Denmark" Value="DK"></asp:ListItem>
            <asp:ListItem Text="Finland" Value="FI"></asp:ListItem>
            <asp:ListItem Text="France" Value="FR"></asp:ListItem>
            <asp:ListItem Text="Germany" Value="DE"></asp:ListItem>
            <asp:ListItem Text="Italy" Value="IT"></asp:ListItem>
            <asp:ListItem Text="Kenya" Value="KE"></asp:ListItem>
            <asp:ListItem Text="Mexico" Value="MX"></asp:ListItem>
            <asp:ListItem Text="Norway" Value="NO"></asp:ListItem>
            <asp:ListItem Text="Romania" Value="RO"></asp:ListItem>
            <asp:ListItem Text="SouthAfrica" Value="ZA"></asp:ListItem>
            <asp:ListItem Text="Spain" Value="ES"></asp:ListItem>
            <asp:ListItem Text="Sweden" Value="SE"></asp:ListItem>
            <asp:ListItem Text="Switzerland" Value="CH"></asp:ListItem>
            <asp:ListItem Text="Turkey" Value="TR"></asp:ListItem>
            <asp:ListItem Text="UK" Value="UK"></asp:ListItem>
            <asp:ListItem Text="Vietnam" Value="VN"></asp:ListItem>
        </asp:CheckBoxList>
    </div>
</asp:Content>

