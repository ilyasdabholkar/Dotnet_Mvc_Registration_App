using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterModule.Models
{
    public class UserJobType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserJobId { get; set; }
        public int UserId { get; set; }
        public int JobId { get; set; }

        [ForeignKey("JobId")]
        public virtual JobType? JobType { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

    }
}
