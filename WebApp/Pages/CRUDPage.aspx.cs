using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DBSystem.BLL;
using DBSystem.ENTITIES;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;

namespace WebApp.Pages
{
    public partial class CRUDPage : System.Web.UI.Page
    {
        static string pagenum = "";
        static string sid = "";
        static string add = "";
        List<string> errormsgs = new List<string>();
        private static List<Student> StudentList = new List<Student>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();

            if (!Page.IsPostBack)
            {
                pagenum = Request.QueryString["page"];
                sid = Request.QueryString["sid"];
                add = Request.QueryString["add"];
                BindCountryList();

                if (string.IsNullOrEmpty(sid))
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    StudentController sysmgr = new StudentController();
                    Student info = null;
                    info = sysmgr.FindByPKID(int.Parse(sid));
                    if (info == null)
                    {
                        errormsgs.Add("Student is no longer on file.");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        Clear_Click(sender, e);
                    }
                    else
                    {
                        StudentNumber.Text = info.StudentNumber.ToString();
                        FirstName.Text = info.FirstName;
                        LastName.Text = info.LastName;
                        FirstName.Text = info.FirstName;
                        DisplayName.Text = info.DisplayName;
                        CountryList.SelectedValue = info.CountryCode;
                        GenderList.SelectedValue = info.Gender;
                        BirthDate.Text = info.BirthDate.ToString("yyyy-MM-dd");
                    }
                }
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
        protected void BindCountryList()
        {
            try
            {
                CountryController sysmgr = new CountryController();
                List<Country> info = null;
                info = sysmgr.List();
                info.Sort((x, y) => x.CountryName.CompareTo(y.CountryName));
                CountryList.DataSource = info;
                CountryList.DataTextField = nameof(Country.CountryName);
                CountryList.DataValueField = nameof(Country.CountryCode);
                CountryList.DataBind();
                CountryList.Items.Insert(0, "Select...");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void Validation(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                errormsgs.Add("First Name is required");
            }
            if (string.IsNullOrEmpty(LastName.Text))
            {
                errormsgs.Add("Last Name is required");
            }
            if (string.IsNullOrEmpty(DisplayName.Text))
            {
                errormsgs.Add("Display Name is required");
            }
            if (CountryList.SelectedIndex == 0)
            {
                errormsgs.Add("Country is required");
            }
            if (GenderList.SelectedIndex == 0)
            {
                errormsgs.Add("Gender is required");
            }
            if (string.IsNullOrEmpty(BirthDate.Text))
            {
                errormsgs.Add("Birthdate is required");
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
           Response.Redirect("StudentsByPartialSearch.aspx");
        }
        protected void Clear_Click(object sender, EventArgs e)
        {
            StudentNumber.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            DisplayName.Text = "";
            BirthDate.Text = "";            
            CountryList.ClearSelection();
            GenderList.ClearSelection();
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            Validation(sender, e);
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    StudentController sysmgr = new StudentController();
                    Student item = new Student();

                    item.FirstName = FirstName.Text.Trim();
                    item.LastName = LastName.Text.Trim();
                    item.DisplayName = DisplayName.Text.Trim();
                    item.BirthDate = DateTime.Parse(BirthDate.Text.Trim());
                    item.CountryCode = CountryList.SelectedValue;
                    item.Gender = GenderList.SelectedValue;

                    int newID = sysmgr.Add(item);
                    StudentNumber.Text = newID.ToString();
                    errormsgs.Add("Student has been added");
                    LoadMessageDisplay(errormsgs, "alert alert-success");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(StudentNumber.Text))
            {
                errormsgs.Add("Search for a student to update");
            }
            else if (!int.TryParse(StudentNumber.Text, out id))
            {
                errormsgs.Add("Student id is invalid");
            }
            Validation(sender, e);
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    StudentController sysmgr = new StudentController();
                    Student item = new Student();
                    item.StudentNumber = id;
                    item.FirstName = FirstName.Text.Trim();
                    item.LastName = LastName.Text.Trim();
                    item.DisplayName = DisplayName.Text.Trim();
                    item.BirthDate = DateTime.Parse(BirthDate.Text.Trim());
                    item.CountryCode = CountryList.SelectedValue;
                    item.Gender = GenderList.SelectedValue;

                    int rowsaffected = sysmgr.Update(item);
                    if (rowsaffected > 0)
                    {
                        errormsgs.Add("Student has been updated");
                        LoadMessageDisplay(errormsgs, "alert alert-success");                        
                    }
                    else
                    {
                        errormsgs.Add("Student has not been updated. Student was not found");
                        LoadMessageDisplay(errormsgs, "alert alert-info");                        
                    }                    
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(StudentNumber.Text))
            {
                errormsgs.Add("Search for a student to delete");
            }
            else if (!int.TryParse(StudentNumber.Text, out id))
            {
                errormsgs.Add("Student number is invalid");
            }
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "CallFunction", "CallFunction();", true);
                    DBSystem.BLL.StudentController sysmgr = new DBSystem.BLL.StudentController();
                    int rowsaffected = sysmgr.Delete(id);
                    if (rowsaffected > 0)
                    {
                        errormsgs.Add("Student has been deleted");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        Clear_Click(sender, e);
                    }
                    else
                    {
                        errormsgs.Add("Student was not found");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                    }

                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
    }
}