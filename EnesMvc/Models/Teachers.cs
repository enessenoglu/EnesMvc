using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnesMvc.Models
{
    [Table ("tblTeachers")]
    public class Teachers
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(30),Required]
        public string Name { get; set; }
        [StringLength(30), Required]
        public string Surname { get; set; }
        [StringLength(30), Required]
        public string Department { get; set; }
        public virtual List<Students> Students { get; set; }
    }
}