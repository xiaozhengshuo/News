using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Admin
{
    public partial class NewsRepeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTitleSort_Click1(object sender, EventArgs e)
        {
            hfSortField.Value = "Title";
            if (ViewState["TitleClick"].ToString() == "0")
            {
                ViewState["TitleClick"] = "1";
                hfDirection.Value = "ASC";
                btnTitleSort.Text = "按标题降序";
            }
            else if (ViewState["TitleClick"].ToString() == "1")
            {
                ViewState["TitleClick"] = "0";
                hfDirection.Value = "DESC";
                btnTitleSort.Text = "按标题升序";
            }
        }

        protected void btnPubDateSort_Click1(object sender, EventArgs e)
        {
            hfSortField.Value = "PubDate";
            if (ViewState["PubDateClick"].ToString() == "0")
            {
                ViewState["PubDateClick"] = "1";
                hfDirection.Value = "ASC";
                btnPubDateSort.Text = "按日期降序";
            }
            else if (ViewState["PubDateClick"].ToString() == "1")
            {
                ViewState["PubDateClick"] = "0";
                hfDirection.Value = "DESC";
                btnPubDateSort.Text = "按日期升序";
            }
        }
    }
}