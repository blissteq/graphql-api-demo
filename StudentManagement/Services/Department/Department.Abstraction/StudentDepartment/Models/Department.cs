using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Messaging;

namespace StudentDepartment.Abstraction.StudentDepartment.Models
{
   public class Department: BaseQueryModel, ICommandData, IEventData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

      
    }
}
