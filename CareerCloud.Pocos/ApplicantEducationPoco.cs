using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos
{
   [Table("Applicant_Educations")] 
    public class ApplicantEducationPoco : IPoco
    {
        
        [Key]
        public Guid Id { get; set;}

        [Column("Major")]
        public string Major { get; set; }
 
        [Column("Certificate_Diploma")]
        public string CertificateDiploma { get; set; }
        
        [Column("Start_Date")]
        public DateTime? StartDate { get; set; }
        
        [Column("Completion_Date")]
        public DateTime? CompletionDate { get; set; }
        
        [Column("Completion_Percent")]
        public byte? CompletionPercent { get; set; }
       
        [Column("Applicant")]
        public Guid Applicant { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        //Navigation properties
        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }

    }
}
