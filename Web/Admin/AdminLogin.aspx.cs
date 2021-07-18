using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NewsModels;
using NewsBLL;

namespace Web.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Page.IsValid)
                {
                    string loginName = txtLoginName.Text.Trim();
                    string loginPwd = txtLoginPwd.Text.Trim();
                    User user;
                    if (UserManager.UserLogin(loginName, loginPwd, out user))
                    {
                        
                      
                            Response.Redirect("~/Admin/NewsCategoriesManager.aspx");
                        
                    }
                    else
                    {
                        Common.Message.RegScript(this, "密码错误!");
                    }
                }
                else
                {
                    Common.Message.RegScript(this, "用户名或密码不正确，请重新填写！");
                }
            }
        }

        protected void btnAddUser1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AddUser.aspx");
        }
    }
}