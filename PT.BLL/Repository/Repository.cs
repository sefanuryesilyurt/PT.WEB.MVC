using PT.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.BLL.Repository
{

        public class DepartmanRepo : RepositoryBase<Department, int> { }
        public class SalaryRepo : RepositoryBase<SalaryLog, int> { }
        public class LaborlogRepo:RepositoryBase<Laborlog, int> { }

  
}
