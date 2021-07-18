using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Admin
{
    public partial class NewsManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["TitleClick"] = "0";
                ViewState["PubDateClick"] = "0";
            }
        }

        protected void ddlNewsCategorySearch_DataBound(object sender, EventArgs e)
        {
            ListItem item = new ListItem("全部", "-1");
            ddlNewsCategorySearch.Items.Insert(0, item);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (txtStartTime.Text != "")
                {
                    try
                    {
                        Convert.ToDateTime(txtStartTime.Text);
                    }
                    catch (Exception)
                    {
                        Common.Message.RegScript(this, "日期格式错误！");
                        return;
                    }
                }
                if (txtEndTime.Text != "")
                {
                    try
                    {
                        Convert.ToDateTime(txtEndTime.Text);
                    }
                    catch (Exception)
                    {
                        Common.Message.RegScript(this, "日期格式错误！");
                        return;
                    }
                }
                if (ddlNewsCategorySearch.SelectedIndex == 0)
                {
                    if (txtStartTime.Text == "")
                    {
                        if (txtEndTime.Text == "")
                        {
                            hfSearch.Value = "Title LIKE '%" + txtTitleSearch.Text.
                                Trim() + "%' AND Author LIKE '%" + txtAuthorSearch.Text.
                                Trim() + "%'";
                        }
                        else
                        {
                            hfSearch.Value = "Title LIKE '%" + txtTitleSearch.Text.Trim() +
                                "%' AND Author LIKE '%" + txtAuthorSearch.Text.Trim() + "%' AND PubDate>= '" +
                                txtStartTime.Text.Trim() + "'";
                        }
                    }
                    else
                    {
                        if (txtEndTime.Text == "")
                        {
                            hfSearch.Value = "Title LIKE '%" + txtTitleSearch.Text.Trim() +
                                "%' AND Author LIKE '%" + txtAuthorSearch.Text.Trim() + "%' AND PubDate<= '" + txtEndTime.Text.Trim() + "'";
                        }
                    }
                }
                else
                {
                    if (txtStartTime.Text == "")
                    {
                        if (txtEndTime.Text == "")
                        {
                            hfSearch.Value = "NewsCategoryId=" + ddlNewsCategorySearch.SelectedIndex
                                + " AND Title LIKE '%" + txtTitleSearch.Text.Trim() + "%' AND Author LIKE '%"
                                + txtAuthorSearch.Text.Trim() + "%'";
                        }
                        else
                        {
                            hfSearch.Value = "NewsCategoryId=" + ddlNewsCategorySearch.SelectedValue
                                + " AND Title LIKE '%" + txtTitleSearch.Text.Trim() + "%' AND Author LIKE '%"
                                + txtAuthorSearch.Text.Trim() + "%' AND PubDate<='" + txtEndTime.Text.Trim() + "'";
                        }
                    }
                    else
                    {
                        if (txtEndTime.Text == "")
                        {
                            hfSearch.Value = "NewsCategoryId=" + ddlNewsCategorySearch.SelectedValue
                                 + " AND Title LIKE '%" + txtTitleSearch.Text.Trim() + "%' AND Author LIKE '%"
                                 + txtAuthorSearch.Text.Trim() + "%' AND PubDate<='" + txtStartTime.Text.Trim() + "'";
                        }
                        else
                        {
                            hfSearch.Value = "NewsCategoryId=" + ddlNewsCategorySearch.SelectedValue
                               + " AND Title LIKE '%" + txtTitleSearch.Text.Trim() + "%' AND Author LIKE '%"
                               + txtAuthorSearch.Text.Trim() + "%' AND PubDate<='" + txtStartTime.Text.Trim() 
                               + "' AND PubDate<='"+ txtEndTime.Text.Trim() +"'";
                        }
                    }
                }
            }
        }

        protected void btnTitleSort_Click(object sender, EventArgs e)
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

        protected void btnPubDateSort_Click(object sender, EventArgs e)
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