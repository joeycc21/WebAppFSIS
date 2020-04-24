using DBSystem.BLL;
using DBSystem.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Pages
{
    public partial class StudentsByGender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
            if (!Page.IsPostBack)
            {
                
            }
        }      

        protected void Search_Click(object sender, EventArgs e)
        {
            if (GenderList.SelectedIndex == 0)
            {
                MessageLabel.Text = "Select a gender to view students.";
            }
            else
            {
                StudentGridView.DataSource = DSStudents;
                StudentGridView.DataBind();
            }
        }

        public List<Student> StudentList(string gender)
        {
            StudentController sysmgr = new StudentController();
            List<Student> info = null;
            info = sysmgr.FindByGender(gender);
            info.Sort((x, y) => x.FullName.CompareTo(y.FullName));
            return info;
        }

        public List<Country> CountryList()
        {
            CountryController sysmgr = new CountryController();
            List<Country> info = null;
            info = sysmgr.List();
            info.Sort((x, y) => x.CountryName.CompareTo(y.CountryName));
            return info;
        }

        protected void StudentGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StudentGridView.PageIndex = e.NewPageIndex;
            Search_Click(sender, new EventArgs());
        }
    }
}