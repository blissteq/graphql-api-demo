

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Messaging;

namespace StudentDetails.Abstraction.Models
{
   public class StudentDTO: BaseQueryModel, ICommandData, IEventData
    {
      
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public Guid DepartmentId { get; set; }
       public string Level { get; set; }
       
    }
}
