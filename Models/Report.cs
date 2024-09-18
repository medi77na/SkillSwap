using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/* Model That stores all reports made by one user to another user. */
namespace SkillSwap.Models
{
    [Table("Reports")]
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("title")]
        [MaxLength(100)]
        public required string TitleReport { get; set; }
        [Column("description")]
        [MaxLength(100)]
        public required string Description { get; set; }

        [Column("date_report")]
        public required DateOnly DateReport { get; set; }

        [Column("action_taken")]
        [MaxLength(100)]
        public required string ActionTaken {get; set;}

        [Column("id_state_report")]
        public required int IdState {get;set;}

        [Column("id_user")]
        public int IdUser { get; set; }
        [Column("id_user_reported")]
        public int IdReportedUser { get; set; }

        [ForeignKey("IdState")]
        public StateReport StateReport {get; set;} 

        [ForeignKey("IdUser")]
        public User User { get; set; }

        [ForeignKey("IdReportedUser")]
        public User UserReported { get; set; }
    }
}