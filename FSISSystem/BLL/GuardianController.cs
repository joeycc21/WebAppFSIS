using FSISSystem.DAL;
using FSISSystem.ENTITIES;
using System.Collections.Generic;
using System.Linq;

namespace FSISSystem.BLL
{
    public class GuardianController
    {
        public List<Guardian> Guardian_List()
        {
            using (var context = new FSISContext())
            {
                return context.Guardians.ToList();
            }
        }
    }
}
