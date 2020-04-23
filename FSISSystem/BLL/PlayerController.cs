using FSISSystem.DAL;
using FSISSystem.ENTITIES;
using System.Collections.Generic;
using System.Linq;

namespace FSISSystem.BLL
{
    public class PlayerController
    {
        public List<Player> Player_List()
        {
            using (var context = new FSISContext())
            {
                return context.Players.ToList();
            }
        }

        public Player Player_Find(int playerid)
        {
            using (var context = new FSISContext())
            {
                return context.Players.Find(playerid);
            }
        }

        public int Player_Add(Player item)
        {            
            using (var context = new FSISContext())
            {                
                context.Players.Add(item);
                context.SaveChanges();                
                return item.PlayerID;
            }
        }
    }
}
