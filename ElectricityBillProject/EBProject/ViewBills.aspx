<%@ Page Title="View Bills" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ViewBills.aspx.cs" Inherits="ElectricityBillingSystem.ViewBills" %>
<asp:Content ID="c1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Retrieve the last Entered bills</h2>
    
    <span class="label">Enter Number of Bills To Generate</span>
    <asp:TextBox ID="txtN" runat="server" TextMode="Number" Text="5" />
    <asp:Button ID="btnFetch" runat="server" Text="Get Bills" OnClick="btnFetch_Click" />
    <br /><br />

   
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="grid">
    <Columns>
        <asp:BoundField DataField="ConsumerNo" HeaderText="Consumer No" />
        <asp:BoundField DataField="ConsumerName" HeaderText="Consumer Name" />
        <asp:BoundField DataField="Units" HeaderText="Units" />
        <asp:BoundField DataField="Amount" HeaderText="Amount (Rs)" DataFormatString="{0:0.##}" />
    </Columns>
</asp:GridView>

    <br />

    <asp:Literal ID="litSummary" runat="server" />
</asp:Content>
