using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO;

namespace Project5
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxPassword.Text == tbxPasswordConf.Text)
                {
                    string result = Reg.register(tbxUsername.Text, tbxPassword.Text);
                    if (result == "registered")
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        lblRegister.Text = result;
                    }
                }
                else
                {
                    lblRegister.Text = "Passwords Do not match";
                }
            }
            catch
            {
                lblRegister.Text = "Error creating account";
            }
        }
    }
    public static class Reg
    {
        public static string register(string username, string password)
        {

            string userData = HttpContext.Current.Server.MapPath("~/App_Data/Member.xml");
            string ret = "0";
            XDocument xdoc;
            //if user name is empty, notify
            if (username.Length < 1)
            {
                return "no username entered";
            }
            try
            {
                //user data file exists; adds new user to xml file
                if (File.Exists(userData))
                {
                    xdoc = XDocument.Load(userData); ;
                    foreach (XElement usr in xdoc.Descendants("user"))
                    {
                        //if node containing username is found then user name already exists
                        if (usr.Element("username").Value == username)
                        {
                            ret = string.Format("user {0} already exists", username);
                        }
                    }
                    int strlen = password.Length;
                    if (password.Length < 6)
                    {
                        ret = "not registered: password must be atleast six characters long";
                    }
                    if (ret == "0")
                    {
                        xdoc = XDocument.Load(userData);
                        //find the root element users
                        XElement users = xdoc.Element("users");
                        //add username and password
                        users.Add(new XElement("user",
                                    new XElement("username", username),
                                    //encrypt password with DLL
                                    new XElement("password", Encryption.EncryptionDecryption.encrypt(password))));
                        xdoc.Save(userData);
                        ret = string.Format("registered");
                    }
                }
                else
                {
                    //creates user data xml file if it does not already exists
                    xdoc = new XDocument(new XElement("users",
                                new XElement("user",
                                new XElement("username", username),
                                //encrypt password with DLL
                                new XElement("password", Encryption.EncryptionDecryption.encrypt(password)))));
                    xdoc.Save(userData);
                    ret = string.Format("registered");
                }
            }
            catch (Exception ex)
            {
                string hostname = System.Environment.MachineName;
                string err = string.Format("error: could not register user\n current directory: {0} \n" +
                    " on host {1} ex: {2}", "", hostname, ex);
                ret = err;
            }

            return ret;
        }
    }
}