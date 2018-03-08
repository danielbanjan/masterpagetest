<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeaturedAndDeboost.aspx.cs" Inherits="FeaturedAndDeboost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
    Featured And Deboost
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">        
    <div style="width:15%;float:left;">
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
    </div>
    <div style="width:85%;float:left;">
        <div id="div1" class="footer" style="font-size:20px;padding:15px;" runat = "server" ></div>
        <div id="gv_featured_title_id" class="footer" runat = "server"><h3>Featured Campaigns</h3></div>
        <div id="gv_featured_id" runat="server" style="width: 100%;max-height: 200px; resize: both; overflow: auto; ">
            <asp:GridView ID="featured_gv" runat="server" AllowSorting="True" AutoGenerateEditButton="True">
            </asp:GridView>
        </div>
        <div id="div2" class="footer" style="font-size:20px; padding:15px;" runat = "server" ></div>
        <div id="gv_deboost_title_id" class="footer" runat = "server"><h3>Deboost Campaigns</h3> </div>
        <div id="gv_deboost_id" runat="server" style="width: 100%;  max-height: 200px; resize: both; overflow: auto;">
            <asp:GridView ID="deboost_gv" runat="server" AllowSorting="True" AutoGenerateEditButton="True">
            </asp:GridView>
        </div>
    </div>
</asp:Content>

