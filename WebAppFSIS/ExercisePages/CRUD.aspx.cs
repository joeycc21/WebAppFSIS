using FSISSystem.BLL;
using FSISSystem.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppFSIS.ExercisePages
{
    public partial class CRUD : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();

            if (!Page.IsPostBack)
            {
                BindPlayerList();
                BindTeamList();
                BindGuardianList();
            }
        }

        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
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

        #region Loading and Binding of DDLs
        protected void BindTeamList()
        {
            try
            {
                TeamController sysmgr = new TeamController();
                List<Team> info = null;
                info = sysmgr.Team_List();
                info.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                TeamList.DataSource = info;
                TeamList.DataTextField = nameof(Team.TeamName);
                TeamList.DataValueField = nameof(Team.TeamID);
                TeamList.DataBind();
                TeamList.Items.Insert(0, "Select...");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected void BindGuardianList()
        {
            try
            {
                GuardianController sysmgr = new GuardianController();
                List<Guardian> info = null;
                info = sysmgr.Guardian_List();
                info.Sort((x, y) => x.GuardianName.CompareTo(y.GuardianName));
                GuardianList.DataSource = info;
                GuardianList.DataTextField = nameof(Guardian.GuardianName);
                GuardianList.DataValueField = nameof(Guardian.GuardianID);
                GuardianList.DataBind();
                GuardianList.Items.Insert(0, "Select...");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected void BindPlayerList()
        {
            try
            {
                PlayerController sysmgr = new PlayerController();
                List<Player> info = null;
                info = sysmgr.Player_List();
                info.Sort((x, y) => x.PlayerName.CompareTo(y.PlayerName));
                PlayerList.DataSource = info;
                PlayerList.DataTextField = nameof(Player.PlayerName);
                PlayerList.DataValueField = nameof(Player.PlayerID);
                PlayerList.DataBind();
                PlayerList.Items.Insert(0, "Select...");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        #endregion

        protected void Clear_Click(object sender, EventArgs e)
        {
            Clear_Fields();
        }

        protected void Clear_Fields()
        {
            PlayerID.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Age.Text = "";
            GenderList.SelectedValue = "";
            AlbertaHealthCareNumber.Text = "";
            MedicalAlertDetails.Text = "";
            PlayerList.ClearSelection();
            TeamList.ClearSelection();
            GuardianList.ClearSelection();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (PlayerList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a player to maintain");
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    PlayerController sysmgr = new PlayerController();
                    Player info = null;
                    info = sysmgr.Player_Find(int.Parse(PlayerList.SelectedValue));
                    if (info == null)
                    {
                        errormsgs.Add("Player is no longer on file.");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        Clear_Click(sender, e);
                        BindPlayerList();
                    }
                    else
                    {
                        PlayerID.Text = info.PlayerID.ToString();
                        FirstName.Text = info.FirstName;
                        LastName.Text = info.LastName;
                        Age.Text = info.Age.ToString();
                        AlbertaHealthCareNumber.Text = info.AlbertaHealthCareNumber;
                        MedicalAlertDetails.Text = info.MedicalAlertDetails;
                        GenderList.SelectedValue = info.Gender;
                        TeamList.SelectedValue = info.TeamID.ToString();
                        GuardianList.SelectedValue = info.GuardianID.ToString();
                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void AddPlayer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (GuardianList.SelectedIndex == 0)
                {
                    errormsgs.Add("Guardian is required");
                }

                if (TeamList.SelectedIndex == 0)
                {
                    errormsgs.Add("Team is required");
                }

                if (GenderList.SelectedIndex == 0)
                {
                    errormsgs.Add("Gender is required");
                }

                if (errormsgs.Count > 0)
                {
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                }
                else
                {
                    try
                    {
                        PlayerController sysmgr = new PlayerController();
                        Player item = new Player();

                        item.FirstName = FirstName.Text.Trim();
                        item.LastName = LastName.Text.Trim();
                        item.Age = int.Parse(Age.Text);
                        item.AlbertaHealthCareNumber = AlbertaHealthCareNumber.Text.Trim();
                        item.MedicalAlertDetails = MedicalAlertDetails.Text.Trim();
                        item.Gender = GenderList.SelectedValue;
                        item.TeamID = int.Parse(TeamList.SelectedValue);
                        item.GuardianID = int.Parse(GuardianList.SelectedValue);


                        int newPlayerID = sysmgr.Player_Add(item);
                        PlayerID.Text = newPlayerID.ToString();
                        errormsgs.Add("Player has been added");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        BindPlayerList();
                        PlayerList.SelectedValue = PlayerID.Text;
                    }
                    catch (DbUpdateException ex)
                    {
                        if (ex.InnerException != null)
                        {
                            errormsgs.Add(ex.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(ex.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (Exception ex)
                    {
                        errormsgs.Add(GetInnerException(ex).ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                }
            }
        }

        protected void UpdatePlayer_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                if (GuardianList.SelectedIndex == 0)
                {
                    errormsgs.Add("Guardian is required");
                }

                if (TeamList.SelectedIndex == 0)
                {
                    errormsgs.Add("Team is required");
                }

                if (GenderList.SelectedIndex == 0)
                {
                    errormsgs.Add("Gender is required");
                }

                int playerid = 0;
                if (string.IsNullOrEmpty(PlayerID.Text))
                {
                    errormsgs.Add("Search for a player to update");
                }
                else if (!int.TryParse(PlayerID.Text, out playerid))
                {
                    errormsgs.Add("Player id is invalid");
                }
                else if (playerid < 1)
                {
                    errormsgs.Add("Player id is invalid");
                }

                if (errormsgs.Count > 0)
                {
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                }
                else
                {
                    try
                    {
                        PlayerController sysmgr = new PlayerController();
                        Player item = new Player();

                        item.PlayerID = playerid;
                        item.FirstName = FirstName.Text.Trim();
                        item.LastName = LastName.Text.Trim();
                        item.Age = int.Parse(Age.Text);
                        item.AlbertaHealthCareNumber = AlbertaHealthCareNumber.Text.Trim();
                        item.MedicalAlertDetails = MedicalAlertDetails.Text.Trim();
                        item.Gender = GenderList.SelectedValue;
                        item.TeamID = int.Parse(TeamList.SelectedValue);
                        item.GuardianID = int.Parse(GuardianList.SelectedValue);


                        int rowsaffected = sysmgr.Player_Update(item);
                        if (rowsaffected > 0)
                        {
                            errormsgs.Add("Player has been updated");
                            LoadMessageDisplay(errormsgs, "alert alert-success");
                            BindPlayerList();
                            PlayerList.SelectedValue = PlayerID.Text;
                        }
                        else
                        {
                            errormsgs.Add("Player has not been updated. Player was not found");
                            LoadMessageDisplay(errormsgs, "alert alert-info");
                            BindPlayerList();
                        }
                    }
                    catch (DbUpdateException ex)
                    {                        
                        if (ex.InnerException != null)
                        {
                            errormsgs.Add(ex.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(ex.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (Exception ex)
                    {
                        errormsgs.Add(GetInnerException(ex).ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                }
            }
        }

        protected void DeletePlayer_Click(object sender, EventArgs e)
        {
            int playerid = 0;
            if (string.IsNullOrEmpty(PlayerID.Text))
            {
                errormsgs.Add("Search for a player to delete");
            }
            else if (!int.TryParse(PlayerID.Text, out playerid))
            {
                errormsgs.Add("Player id is invalid");
            }
            else if (playerid < 1)
            {
                errormsgs.Add("Player id is invalid");
            }

            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    PlayerController sysmgr = new PlayerController();

                    int rowsaffected = sysmgr.Player_Delete(playerid);

                    if (rowsaffected > 0)
                    {
                        errormsgs.Add("Player has been deleted");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        BindPlayerList();
                        Clear_Fields();
                    }
                    else
                    {
                        errormsgs.Add("Player has not been deleted. Player was not found");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        BindPlayerList();
                    }
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException != null)
                    {
                        errormsgs.Add(ex.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(ex.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
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