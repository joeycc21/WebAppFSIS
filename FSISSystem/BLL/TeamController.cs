using FSISSystem.DAL;
using FSISSystem.ENTITIES;
using System.Collections.Generic;
using System.Linq;

namespace FSISSystem.BLL
{
    public class TeamController
    {
        public Team Teams_FindByID(int teamid)
        {
            using (var context = new FSISContext())
            {
                return context.Teams.Find(teamid);
            }
        }

        public List<Team> Team_List()
        {
            using (var context = new FSISContext())
            {
                return context.Teams.ToList();
            }
        }
    }
}