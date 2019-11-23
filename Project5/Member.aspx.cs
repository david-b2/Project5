using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            lblResults.Text = "";
            lbxResults.Items.Clear();
            try
            {
                List<string> stores = Location.FindNearestStore(tbxStorename.Text, tbxLocation.Text, tbxRadius.Text);
                //If there were no search results
                if (stores.Count == 0)
                {
                    lbxResults.Visible = false;
                    lblResults.Text = "No Results Found";
                }
                else //there were 1 or more results found
                {
                    lbxResults.Visible = true;
                    foreach(string result in stores)
                    {
                        lbxResults.Items.Add(result);
                    }
                }
            }
            catch
            {
                string ret = "could not find store";
            }
        }

       
    }
}