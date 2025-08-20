using System;

namespace ElectricityBillingSystem
{
    public partial class AddBill : System.Web.UI.Page
    {
        private readonly BillValidator validator = new BillValidator();
        private readonly ElectricityBoard board = new ElectricityBoard();

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
          
                if (!int.TryParse(txtUnits.Text, out int units))
                {
                    lblMsg.CssClass = "msg-err";
                    lblMsg.Text = "Please enter a valid integer for units.";
                    return;
                }

           
                validator.ValidateConsumerNumber(txtConsumerNo.Text.Trim());
                validator.ValidateConsumerName(txtConsumerName.Text.Trim());
                validator.ValidateUnitsConsumed(units);



                // Construct model and validate ConsumerNumber (throws FormatException if invalid)
                var ebill = new ElectricityBill
                {
                    ConsumerNumber = txtConsumerNo.Text.Trim(), // may throw FormatException
                    ConsumerName = txtConsumerName.Text.Trim(),
                    UnitsConsumed = units
                };

                // Calculate bill (spec slab)
                board.CalculateBill(ebill);

                // Save to DB
                board.AddBill(ebill);

                lblMsg.CssClass = "msg-ok";
                lblMsg.Text = $"Consumer No : {ebill.ConsumerNumber}, Consumer Name : {ebill.ConsumerName}, Units Consumed : {ebill.UnitsConsumed}, Bill Amount : {ebill.BillAmount:0.##}";

                // Clear inputs for next user
                txtConsumerNo.Text = txtConsumerName.Text = txtUnits.Text = "";
            }
            catch (FormatException fe)
            {
                // Validation 1: show EXACT message from exception object
                lblMsg.CssClass = "msg-err";
                lblMsg.Text = fe.Message; // "Invalid Consumer Number"
            }
            catch (Exception ex)
            {
                lblMsg.CssClass = "msg-err";
                lblMsg.Text = "Error: " + ex.Message;
            }
        }
    }
}
