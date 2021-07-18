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
        /// ע����ʾ��Ϣ
        /// </summary>
        /// <param name="page">ҳ�����</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void RegScript(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "window.alert('" + msg + "');", true);
        }

        /// <summary>
        /// ע����ʾ��Ϣ��ת���Ӧҳ��
        /// </summary>
        /// <param name="page">ҳ�����</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">ҳ��ת���ַ</param>
        public static void RegScript(Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "window.alert('" + msg + "');document.location='" + url + "';", true);
        }
    }
}
