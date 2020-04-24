using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DBSystem.ENTITIES
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string CountryCode { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
