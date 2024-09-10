using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSwap.Models
{
    [Table("Users_abilities")]
    public class UserAbility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set;}
        [Column("id_user")]
        public int IdUser { get; set;}
        [Column("id_ability")]
        public int IdAbility { get; set;}
        [ForeignKey("IdUser")]
        public User User { get; set; }
        [ForeignKey("IdAbility")]
        public Ability Ability { get; set; }
    }
}