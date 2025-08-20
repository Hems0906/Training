<%@ Page Title="Add Bill" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AddBill.aspx.cs" Inherits="ElectricityBillingSystem.AddBill" %>
<asp:Content ID="c1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add Electricity Bill</h2>
    <span class="label">Consumer Number (EB + 5 digits)</span>
    <asp:TextBox ID="txtConsumerNo" runat="server" />
    <span class="label">Consumer Name</span>
    <asp:TextBox ID="txtConsumerName" runat="server" />
    <span class="label">Units Consumed</span>
    <asp:TextBox ID="txtUnits" runat="server" TextMode="Number" />
    <br /><br />
    <asp:Button ID="btnAdd" runat="server" Text="Calculate & Save" OnClick="btnAdd_Click" />
    <br /><br />
    <asp:Label ID="lblMsg" runat="server" />
</asp:Content>
