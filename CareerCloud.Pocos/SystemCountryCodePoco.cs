﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("System_Country_Codes")]
    public class SystemCountryCodePoco
    {
        [Key]
        public string Code { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        //Navigation properties
        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }

        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }

        public virtual ICollection<CompanyLocationPoco> CompanyLocations { get; set; }

    }
}
