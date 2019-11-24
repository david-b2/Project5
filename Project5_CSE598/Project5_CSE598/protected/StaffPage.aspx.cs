using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Xml;
using System.Web.Security;
/***BY: ERICK DUARTE, Staff page populates proper message regarding signed in staff member either via
 * login or cookies method. Cookies only utilized if ssl present, page also allows Staff member to add
 * new staff member along with credentials onto file: App_Data/Staff.xml , which is the file used by
 * StaffLogin.aspx for verifying user credentials and redirecting user to StaffPage.aspx if so, thus 
 * grnting access to the protected source. Used lectures 24,21 as reference***/
public partial class protected_StaffPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie myCookies = Request.Cookies["staffCookie"];

        if(Context.User.Identity.Name != null || Context.User.Identity.Name != "")
        {
            GreetingLabel.Text = "Hello " + Context.User.Identity.Name + ", Welcome to the staff page!";
        }else if (myCookies.Secure)
        {//only use cookies if ssl avail, for security
            if ((myCookies != null) || (myCookies["UserName"] != ""))
            {
                GreetingLabel.Text = "Hello, " + myCookies["UserName"] + ", Welcome to the staff page!";
            }
        }
        

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string memberName = TextBoxName.Text;
        string memberUserName = TextBoxUserName.Text;
        string memberPwd = TextBoxPwd.Text;
        string filepath = HttpRuntime.AppDomainAppPath + @"\App_Data\Staff.xml";
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(filepath);
        XmlElement rootElement = myDoc.DocumentElement;

        XmlElement newMember = myDoc.CreateElement("Member", rootElement.NamespaceURI);
        rootElement.AppendChild(newMember);
        XmlElement newUser = myDoc.CreateElement("Name", rootElement.NamespaceURI);
        newMember.AppendChild(newUser);
        newUser.InnerText = memberName;

        XmlElement newUserName = myDoc.CreateElement("UserName", rootElement.NamespaceURI);
        newMember.AppendChild(newUserName);
        newUserName.InnerText = memberUserName;

        XmlElement newPwd = myDoc.CreateElement("Password", rootElement.NamespaceURI);
        newMember.AppendChild(newPwd);
        newPwd.InnerText = memberPwd;

        myDoc.Save(filepath);
        TextBoxName.Text = "";
        TextBoxUserName.Text = "";
        TextBoxPwd.Text = "";
        ResultLabel.Text = "Successfully Added Staff Member: " + memberName + ", Check Staff.xml file under App_Data to verify!";
    }

    protected void ButtonSignOut_Click(object sender, EventArgs e)
    {
        Response.Cookies.Clear();//clear all cookies as well when signing out
        FormsAuthentication.SignOut();
        Server.Transfer("Default.aspx");
    }
}