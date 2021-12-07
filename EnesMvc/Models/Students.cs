using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnesMvc.Models
{

    [Table ("tblStudents")]
    public class Students
    {   
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentNo { get; set; }
        [StringLength(30),Required]
        public string Name { get; set; }
        [StringLength(30),Required]
        public string Surname { get; set; }

        public virtual Teachers Teachers { get; set; }
    }
}