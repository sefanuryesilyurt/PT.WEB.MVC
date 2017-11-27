using Microsoft.AspNet.Identity.EntityFramework;
using PT.Entity.IdentyModel;
using PT.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PT.DAL
{
  public  class MyContext:IdentityDbContext<ApplicationUser>
    {
     public MyContext()
            :base("name=MyCon")
        {

        }

        public virtual DbSet <Department> Departments{ get; set; }
        public virtual DbSet<Laborlog> Laborlogs { get; set; }
        public virtual DbSet<SalaryLog> SalaryLog { get; set; }
    }
}
