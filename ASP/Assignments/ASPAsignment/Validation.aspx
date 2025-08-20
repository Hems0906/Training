<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validation.aspx.cs" Inherits="ASPAsignment.Validation" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insert Your Details</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .form-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            flex-direction: column;
        }
        .row {
            display: flex;
            align-items: center;
            margin-bottom: 10px;
            width: 400px;
            justify-content: space-between;
        }
        .row label {
            width: 320px;
        }
        .row .input-box {
            flex: 1;
        }
        .row .error {
            color: red;
            font-size: 12px;
            padding-left: 8px;
            width: 200px;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div class="form-container">
        <h1>Insert Your Details</h1>

        <div class="row">
            <label>Name:</label>
            <div class="input-box"><asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
            <asp:Label ID="errName" runat="server" CssClass="error"></asp:Label>
        </div>

        <div class="row">
            <label>Family Name:</label>
            <div class="input-box"><asp:TextBox ID="txtFamilyName" runat="server"></asp:TextBox></div>
            <asp:Label ID="errFamilyName" runat="server" CssClass="error"></asp:Label>
        </div>

        <div class="row">
            <label>Address:</label>
            <div class="input-box"><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></div>
            <asp:Label ID="errAddress" runat="server" CssClass="error"></asp:Label>
        </div>

        <div class="row">
            <label>City:</label>
            <div class="input-box"><asp:TextBox ID="txtCity" runat="server"></asp:TextBox></div>
            <asp:Label ID="errCity" runat="server" CssClass="error"></asp:Label>
        </div>

        <div class="row">
            <label>Zip Code:</label>
            <div class="input-box"><asp:TextBox ID="txtZip" runat="server"></asp:TextBox></div>
            <asp:Label ID="errZip" runat="server" CssClass="error"></asp:Label>
        </div>

        <div class="row">
            <label>Phone:</label>
            <div class="input-box"><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></div>
            <asp:Label ID="errPhone" runat="server" CssClass="error"></asp:Label>
        </div>

        <div class="row">
            <label>E-mail:</label>
            <div class="input-box"><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></div>
            <asp:Label ID="errEmail" runat="server" CssClass="error"></asp:Label>
        </div>

        <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" />
        &nbsp;
        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />

        <br /><br />
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </div>
</form>

<script runat="server">
  

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        errName.Text = "";
        errFamilyName.Text = "";
        errAddress.Text = "";
        errCity.Text = "";
        errZip.Text = "";
        errPhone.Text = "";
        errEmail.Text = "";
        lblResult.Text = "";

        bool isValid = true;

        string name = txtName.Text.Trim();
        string familyName = txtFamilyName.Text.Trim();
        string address = txtAddress.Text.Trim();
        string city = txtCity.Text.Trim();
        string zip = txtZip.Text.Trim();
        string phone = txtPhone.Text.Trim();
        string email = txtEmail.Text.Trim();

        if (string.IsNullOrEmpty(name))
        {
            errName.Text = "Required";
            isValid = false;
        }
        if (string.IsNullOrEmpty(familyName))
        {
            errFamilyName.Text = "Required";
            isValid = false;
        }
        if (!string.IsNullOrEmpty(name) && name.Equals(familyName, StringComparison.OrdinalIgnoreCase))
        {
            errFamilyName.Text = "Cannot be same as Name";
            isValid = false;
        }
        if (address.Length < 2)
        {
            errAddress.Text = "Min 2 chars";
            isValid = false;
        }
        if (city.Length < 2)
        {
            errCity.Text = "Min 2 chars";
            isValid = false;
        }
        if (!Regex.IsMatch(zip, @"^\d{5}$"))
        {
            errZip.Text = "5 digits";
            isValid = false;
        }
        if (!Regex.IsMatch(phone, @"^\d{2,3}-\d{7}$"))
        {
            errPhone.Text = "Format XX-XXXXXXX";
            isValid = false;
        }
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            errEmail.Text = "Invalid";
            isValid = false;
        }

        if (isValid)
        {
            lblResult.ForeColor = System.Drawing.Color.Green;
            lblResult.Text = $"<b>Submitted Details:</b><br/>" +
                             $"Name: {name}<br/>" +
                             $"Family Name: {familyName}<br/>" +
                             $"Address: {address}<br/>" +
                             $"City: {city}<br/>" +
                             $"Zip Code: {zip}<br/>" +
                             $"Phone: {phone}<br/>" +
                             $"Email: {email}";
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtFamilyName.Text = "";
        txtAddress.Text = "";
        txtCity.Text = "";
        txtZip.Text = "";
        txtPhone.Text = "";
        txtEmail.Text = "";
        errName.Text = "";
        errFamilyName.Text = "";
        errAddress.Text = "";
        errCity.Text = "";
        errZip.Text = "";
        errPhone.Text = "";
        errEmail.Text = "";
        lblResult.Text = "";
    }
</script>
</body>
</html>

