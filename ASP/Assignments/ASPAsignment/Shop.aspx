<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="ASPAsignment.Shop" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Viewer</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center;">
            <h2>Select a Product</h2>

            <!-- Dropdown List -->
            <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
                <asp:ListItem Text="Select a product" Value=""></asp:ListItem>
                <asp:ListItem Text="Laptop" Value="Laptop"></asp:ListItem>
                <asp:ListItem Text="Smartphone" Value="Smartphone"></asp:ListItem>
                <asp:ListItem Text="Headphones" Value="Headphones"></asp:ListItem>
            </asp:DropDownList>

            <br /><br />

            <!-- Image -->
            <asp:Image ID="imgProduct" runat="server" Width="200px" Height="200px" />

            <br /><br />

            <!-- Button -->
            <asp:Button ID="btnPrice" runat="server" Text="Get Price" OnClick="btnPrice_Click" />

            <br /><br />

            <!-- Price Label -->
            <asp:Label ID="lblPrice" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
        </div>
    </form>

    <script runat="server">
        // Set image on dropdown selection
        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlProducts.SelectedValue)
            {
                case "Laptop":
                    imgProduct.ImageUrl = "https://via.placeholder.com/200x200?text=Laptop";
                    break;
                case "Smartphone":
                    imgProduct.ImageUrl = "https://via.placeholder.com/200x200?text=Smartphone";
                    break;
                case "Headphones":
                    imgProduct.ImageUrl = "https://via.placeholder.com/200x200?text=Headphones";
                    break;
                default:
                    imgProduct.ImageUrl = "";
                    break;
            }
            lblPrice.Text = ""; 
        }

        // Show price when button clicked
        protected void btnPrice_Click(object sender, EventArgs e)
        {
            switch (ddlProducts.SelectedValue)
            {
                case "Laptop":
                    lblPrice.Text = "Price: ₹60,000";
                    break;
                case "Smartphone":
                    lblPrice.Text = "Price: ₹30,000";
                    break;
                case "Headphones":
                    lblPrice.Text = "Price: ₹3,000";
                    break;
                default:
                    lblPrice.Text = "Please select a product.";
                    break;
            }
        }
    </script>
</body>
</html>
