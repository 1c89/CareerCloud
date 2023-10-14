using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Resumes")]
    internal class ApplicantResumePoco:IPoco
    {
        [Key]
        public Guid Id { get; set; }
        [Column("Applicant")] 
        public Guid Applicant { get; set; }

        [Column("Resume")] 
        public string Resume { get; set; }

        [Column("Last_Updated")] 
        public DateTime? LastUpdated { get; set; }
    }
}
