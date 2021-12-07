using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnesMvc.Models
{
    [Table("tblPersons")]
    public class Persons
    {   [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(30),Required]
        public string Name { get; set; }
        [StringLength(30), Required]
        public string Surname { get; set; }
        [Required]
        public int Age { get; set; }
        public virtual List<Addresses> Addresses { get; set; }
    }
}