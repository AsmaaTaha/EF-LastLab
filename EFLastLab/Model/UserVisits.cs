using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLastLab.Model
{
    [Table("UserVisits")]
    public class UserVisits
    {
        public DateTime When { get; set; }
        public User User { get; set; }
        public City City { get; set; }
        [Key]
        [ForeignKey("City")]
        [Column(Order =1)]
        public int CityId { get; set; }
        [Key]
        [ForeignKey("User")]
        [Column(Order = 2)]
        public int UserId { get; set; }

    }
}
