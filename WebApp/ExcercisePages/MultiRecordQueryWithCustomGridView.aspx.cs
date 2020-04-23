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
    public partial class MultiRecordQueryWithCustomGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
            if (!Page.IsPostBack)
            {
                BindList();
            }
        }
        protected void BindList()
        {
            try
            {
                Controller01 sysmgr = new Controller01();
                List<Entity01> info = null;
                info = sysmgr.List();
                info.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                List01.DataSource = info;
                List01.DataTextField = nameof(Entity01.TeamName);
                List01.DataValueField = nameof(Entity01.TeamID);
                List01.DataBind();
                List01.Items.Insert(0, "Select...");
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }
        protected void Fetch_Click(object sender, EventArgs e)
        {
            if (List01.SelectedIndex == 0)
            {
                MessageLabel.Text = "Select a team to view its players.";
            }
            else
            {
                try
                {
                    Controller01 sysmgr01 = new Controller01();
                    Entity01 info01 = null;
                    info01 = sysmgr01.FindByID(int.Parse(List01.SelectedValue));
                    CoachLabel01.Text = "Coach:";
                    CoachLabel02.Text = info01.Coach;
                    AssistantCoachLabel01.Text = "Assistant Coach:";
                    AssistantCoachLabel02.Text = info01.AssistantCoach;
                    WinsLabel01.Text = "Wins:";
                    WinsLabel02.Text = info01.Wins.ToString();
                    LossesLabel01.Text = "Losses:";
                    LossesLabel02.Text = info01.Losses.ToString();

                    Controller02 sysmgr02 = new Controller02();
                    List<Entity02> info02 = null;
                    info02 = sysmgr02.FindByID(int.Parse(List01.SelectedValue));
                    info02.Sort((x, y) => x.PlayerName.CompareTo(y.PlayerName));
                    List02.DataSource = info02;
                    List02.DataBind();
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }
        protected void List02_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List02.PageIndex = e.NewPageIndex;
            Fetch_Click(sender, new EventArgs());
        }        
    }
}