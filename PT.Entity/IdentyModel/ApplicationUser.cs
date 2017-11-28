using Microsoft.AspNet.Identity.EntityFramework;
using PT.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Entity.IdentyModel
{
   public  class ApplicationUser:IdentityUser
    {

        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(35)]

        public string Surname { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public decimal Salary { get; set; }
        public int? DepartmanId { get; set; }
        public string ActivationCode { get; set; }
        [ForeignKey("DepartmanId")]
        public virtual Department Department { get; set; }

        public virtual List<Laborlog> Laborlog { get; set; } = new List<Model.Laborlog>();

        public virtual List<SalaryLog> SalaryLog { get; set; } = new List<Model.SalaryLog>();
    }
}
