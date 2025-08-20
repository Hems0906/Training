<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ElectricityBillingSystem.Home" %>
<asp:Content ID="c1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome to Project Electrifiers </h2>
    <p>Use the navigation above to add bills or view the last Entered bills.</p>
    <ul>
   <%--     <li>Valid Consumer Number format: <b>EB#####</b> (e.g., EB11389)</li>
        <li>Units cannot be negative — otherwise you’ll see “Given units is invalid”.</li>
        <li>Bill is calculated by slab: 0, 1.5, 3.5, 5.5, 7.5 (Rs/unit).</li>--%>
    </ul>
</asp:Content>
