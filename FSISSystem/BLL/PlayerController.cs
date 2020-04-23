using FSISSystem.DAL;
using FSISSystem.ENTITIES;
using System;
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

        public int Player_Update(Player item)
        {
            using (var context = new FSISContext())
            {               
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;             
                return context.SaveChanges();
            }
        }

        public int Player_Delete(int playerid)
        {
            using (var context = new FSISContext())
            {                
                var existing = context.Players.Find(playerid);
                if (existing == null)
                {
                    throw new Exception("Record has been removed from database");
                }
                context.Players.Remove(existing);
                return context.SaveChanges();                
            }
        }
    }
}
