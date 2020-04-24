using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using DBSystem.DAL;
using DBSystem.ENTITIES;
using System.Security.Cryptography.X509Certificates;

namespace DBSystem.BLL
{
    public class StudentController
    {
        public Student FindByPKID(int id)
        {
            using (var context = new Context())
            {
                return context.Student.Find(id);
            }
        }
        public List<Student> List()
        {
            using (var context = new Context())
            {
                return context.Student.ToList();
            }
        }

        public int Add(Student item)
        {
            using (var context = new Context())
            {
                int maxid = context.Student.Max(x => x.StudentNumber);
                item.StudentNumber = maxid + 1;
                context.Student.Add(item);
                context.SaveChanges();
                return item.StudentNumber;
            }
        }

        public int Update(Student item)
        {
            using (var context = new Context())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }

        public int Delete(int studentid)
        {
            using (var context = new Context())
            {
                var existing = context.Student.Find(studentid);
                if (existing == null)
                {
                    throw new Exception("Record has been removed from database");
                }
                context.Student.Remove(existing);
                return context.SaveChanges();
            }
        }

        public List<Student> FindByPartialName(string partialname)
        {
            using (var context = new Context())
            {
                IEnumerable<Student> results =
                    context.Database.SqlQuery<Student>("Students_FindByPartialName @PartialName",
                         new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }

        public List<Student> FindByGender(string gender)
        {
            using (var context = new Context())
            {
                IEnumerable<Student> results =
                    context.Database.SqlQuery<Student>("Students_FindByGender @gender",
                         new SqlParameter("gender", gender));
                return results.ToList();
            }
        }
    }
}
