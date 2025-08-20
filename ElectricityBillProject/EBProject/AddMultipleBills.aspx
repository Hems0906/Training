<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMultipleBills.aspx.cs" Inherits="EBProject.AddMultipleBills" %>

<!DOCTYPE html>
<html>
<head>
    <title>Add Multiple Bills</title>
    <style>
        body { font-family: Arial; background: #eef2f7; }
        .container { width: 80%; margin: 40px auto; background: #fff; padding: 20px; border-radius: 10px; box-shadow: 0 0 10px gray; }
        h2 { text-align: center; }
        table { width: 100%; border-collapse: collapse; margin-top: 20px; }
        th, td { border: 1px solid #ccc; padding: 8px; text-align: center; }
        th { background: #f2f2f2; }
        input[type=text], input[type=number] { width: 95%; padding: 5px; }
        button { padding: 8px 15px; margin: 10px 5px; border: none; border-radius: 5px; cursor: pointer; }
        .add-btn { background: #007bff; color: white; }
        .save-btn { background: #28a745; color: white; float: right; }
        .msg { text-align: center; margin-top: 15px; font-weight: bold; }
    </style>
    <script>
        function addRow() {
            let table = document.getElementById("billTable");
            let row = table.insertRow(-1);

            row.innerHTML = `
                <td><input type="text" name="ConsumerNo" required /></td>
                <td><input type="text" name="ConsumerName" required /></td>
                <td><input type="number" name="Units" required /></td>
            `;
        }
    </script>
</head>
<body>
    <div class="container">
        <h2>Add Multiple Bills</h2>

        <form id="form1" runat="server">
            <table id="billTable">
                <tr>
                    <th>Consumer No</th>
                    <th>Consumer Name</th>
                    <th>Units</th>
                </tr>
                <tr>
                    <td><input type="text" name="ConsumerNo" required /></td>
                    <td><input type="text" name="ConsumerName" required /></td>
                    <td><input type="number" name="Units" required /></td>
                </tr>
            </table>

            <button type="button" class="add-btn" onclick="addRow()">➕ Add Row</button>
            <asp:Button ID="btnSave" runat="server" Text="💾 Save All" CssClass="save-btn" OnClick="btnSave_Click" />

            <asp:Label ID="lblMsg" runat="server" CssClass="msg"></asp:Label>
        </form>
    </div>
</body>
</html>
