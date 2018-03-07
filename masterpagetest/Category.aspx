<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
    Category
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">        
    <div style="padding-top:5px;">Please select a country:</div>
    <div style="padding-top:5px;padding-bottom:25px;">
        <asp:DropDownList ID="Countries" runat="server" OnSelectedIndexChanged="Countries_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Enabled="true" Text="Select Country" Value="-1"></asp:ListItem>
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
        </asp:DropDownList>
    </div>
    <div id="div1" class="footer" style="font-size:20px" runat = "server" ></div>
    <div id="gridviewid" runat="server" style="width: 100%; max-height: 300px; overflow: scroll; ">
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateEditButton="True">
        </asp:GridView>
    </div>
</asp:Content>

