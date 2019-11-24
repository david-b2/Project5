using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5
{
    public partial class ImageVerifier : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.ImageUrl = "~/imageProcess.aspx";//imageProcess
            //Image1.ImageUrl = HttpContext.Current.Server.MapPath("imageProcess.aspx");
            Session["verified"] = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string correctText = Session["generatedString"].ToString();
            if (correctText.Equals(TextBox2.Text))
            {
                Label1.Text = "Verification Successful!";
                Label1.ForeColor = System.Drawing.Color.Green;
                Session["verified"] = true;
                this.Parent.FindControl("btnRegister").Visible = true;
            }
            else
            {
                Label1.Text = "Tthe string you entered is incorrect. please try again";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}