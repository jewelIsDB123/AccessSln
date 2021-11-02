using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Access.Models
{
    public class HostingPackage
    {
        public HostingPackage()
        {
            this.Hostings = new HashSet<Hosting>();
        }
        public int HostingPackageId { get; set; }
        //[Required(ErrorMessage = "HostingPackage Name Required")]
        //[DataType(DataType.Text)]
        //[Display(Name = "HostingPackage Name")]
        public string HostingPackageName { get; set; }
        public virtual ICollection<Hosting> Hostings { get; set; }
    }
}