using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Web.Common
{
    public static class Message
    {
        /// <summary>
        /// 注册提示信息
        /// </summary>
        /// <param name="page">页面对象</param>
        /// <param name="msg">提示信息</param>
        public static void RegScript(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "window.alert('" + msg + "');", true);
        }

        /// <summary>
        /// 注册提示信息并转向对应页面
        /// </summary>
        /// <param name="page">页面对象</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">页面转向地址</param>
        public static void RegScript(Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "window.alert('" + msg + "');document.location='" + url + "';", true);
        }
    }
}
