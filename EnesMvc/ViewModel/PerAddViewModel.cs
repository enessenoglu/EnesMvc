using EnesMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnesMvc.ViewModel
{
    public class PerAddViewModel
    {
        public List<Persons> Persons { get; set; }
        public List<Addresses> Addresses { get; set; }
    }
}