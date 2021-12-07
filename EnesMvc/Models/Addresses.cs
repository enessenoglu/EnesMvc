using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnesMvc.Models
{
    [Table ("tblAddresses")]
    public class Addresses
    {[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        [StringLength(300)]
        public string City { get; set; }

        public virtual Persons Persons { get; set; }
        
    }
}