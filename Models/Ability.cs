using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSwap.Models
{
    [Table("Abilities")]
    public class Ability
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("category")]
        [MaxLength(50)]
        public string Category { get; set; }
        [Column("abilities")]
        [MaxLength(255)]
        public string Abilities { get; set; }
    }
}