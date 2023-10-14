using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CareerCloud.Pocos
{
    internal interface IPoco
    {
        [Key]
        public Guid Id { get; set; }
    }
}
