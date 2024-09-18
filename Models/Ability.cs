using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/* Model that relates to User, as it details the category of a user's knowledge and the skills he/she possesses within that category. */

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
        public string? Category { get; set; }
        [Column("abilities")]
        [MaxLength(255)]
        public string? Abilities { get; set; }
        public User? User{ get; set; }
    }
}