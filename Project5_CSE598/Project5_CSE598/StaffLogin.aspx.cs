using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
/***BY: ERICK DUARTE, StaffLogin page utilizes file App_Data/Staff.xml for verifying user credentials and redirecting 
 * user to StaffPage.aspx if so, thus granting access to the protected source. Also creates a cookie storage for 
 * storing loged in user username, however this is only done if ssl is present for security reasons. If user not
 * present in Staff.xml file then user not logged in as it is not authenticated and thus error message
 * "invalid login is displayed. Used lectures 24,21 as references***/
public partial class protected_StaffPageLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void LoginFunc(object sender, EventArgs e)
    {
            string user = StaffUserName.Text;
            string password = StaffPassword.Text;

            string filepath = HttpRuntime.AppDomainAppPath + @"\App_Data\Staff.xml";
            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(filepath);
            XmlElement rootElement = myDoc.DocumentElement;
            foreach (XmlNode node in rootElement.ChildNodes)
            {
                string memberUserName = node["UserName"].InnerText.Trim();
                string memberUserPwd = node["Password"].InnerText.Trim();

                if (string.Equals(memberUserName, user) && string.Equals(memberUserPwd, password))
                {
                    HttpCookie myCookies = new HttpCookie("staffCookie");
                    if (myCookies.Secure)
                    {//only use cookies if ssl avail, for security
                        myCookies["UserName"] = StaffUserName.Text;
                        myCookies.Expires = DateTime.Now.AddMonths(6);
                        Response.Cookies.Add(myCookies);
                    }
                    FormsAuthentication.RedirectFromLoginPage(StaffUserName.Text, false);
                }

            }
            Output.Text = "Invalid login";
    }
}