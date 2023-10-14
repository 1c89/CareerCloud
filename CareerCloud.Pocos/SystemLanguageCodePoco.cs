using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("System_Language_Codes")]
    internal class SystemLanguageCodePoco
    {
        [Key]
        public string LanguageID { get; set; }

        [Column("Name")]
        public string Name { get; set; }
        
        [Column("Native_Name")]
        public string NativeName { get; set; }
    }
}
