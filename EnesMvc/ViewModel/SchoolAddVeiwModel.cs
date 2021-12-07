using EnesMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnesMvc.ViewModel
{
    public class SchoolAddVeiwModel
    {
        public List<Students> students { get; set; }
        public List<Teachers> teachers { get; set; }
    }
}