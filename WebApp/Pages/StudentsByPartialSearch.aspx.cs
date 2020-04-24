using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DBSystem.BLL;
using DBSystem.ENTITIES;

namespace WebApp.Pages
{
    public partial class StudentsByPartialSearch : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
            if (!Page.IsPostBack)
            {
                
            }
        }

        protected Exception GetInnerException(Exception ex)
        {
            
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StudentName.Text))
            {
                errormsgs.Add("Please enter a partial student name for the search");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                StudentGridView.DataSource = null;
                StudentGridView.DataBind();
            }
            else
            {
                try
                {
                    StudentController sysmgr = new StudentController();
                    List<Student> info = sysmgr.FindByPartialName(StudentName.Text);
                    if (info.Count == 0)
                    {
                        errormsgs.Add("No data found for the partial student name search");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {
                        info.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                        StudentGridView.DataSource = info;
                        StudentGridView.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    if (GetInnerException(ex).ToString().IndexOf("Too many rows") != -1)
                    {
                        errormsgs.Add("Too many rows. Supply more detailed partial name");
                    }
                    else {
                        errormsgs.Add(GetInnerException(ex).ToString());
                    }
                    
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
        protected void StudentGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StudentGridView.PageIndex = e.NewPageIndex;
            Search_Click(sender, new EventArgs());
        }
        protected void StudentGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow agvrow = StudentGridView.Rows[StudentGridView.SelectedIndex];
            string studentid = (agvrow.FindControl("StudentNumber") as Label).Text;
            Response.Redirect("CRUDPage.aspx?sid=" + studentid);
        }
    }
}