using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DBSystem.ENTITIES
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public string CountryCode { get; set; }
        public string CountryName { get; set; }       
    }
}
