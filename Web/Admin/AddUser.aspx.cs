using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsModels;
using NewsBLL;
namespace Web.Admin
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.LoginName = txtLoginName.Text.Trim();
            user.LoginPwd = txtLoginPwd.Text.Trim();
            user.RealName = txtRealName.Text.Trim();
            user.Phone = txtPhone.Text.Trim();
            user.Email = txtPhone.Text.Trim();
            user.Address = txtAddress.Text.Trim();
            user.Role = "2";
            UserManager.AddUser(user);
            Common.Message.RegScript(this, "注册成功！");
        }

        protected void btnQuit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminLogin.aspx");
        }
    }
}