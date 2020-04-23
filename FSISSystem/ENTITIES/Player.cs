using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace FSISSystem.ENTITIES
{
    [Table("Player")]
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        public int GuardianID { get; set; }
        public int TeamID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string AlbertaHealthCareNumber { get; set; }
        public string MedicalAlertDetails { get; set; }

        [NotMapped]
        public string PlayerName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
