using PT.Entity.IdentyModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Entity.Model
{

    [Table("Laborlogs")]
    public class Laborlog : BaseModel
    {
       
        public DateTime StartShift { get; set; } = DateTime.Now;
        public DateTime? EndShift { get; set; }//boş olmaması için ? 
        public string UserId { get; set; }
        [ForeignKey("UserId")]

        public virtual ApplicationUser User { get; set; }
    }
}
