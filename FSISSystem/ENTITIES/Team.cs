using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FSISSystem.ENTITIES
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string Coach { get; set; }
        public string AssistantCoach { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
    }
}
