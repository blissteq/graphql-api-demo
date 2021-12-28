using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;

namespace StudentDepartment.Abstraction.StudentDepartment.Entities
{
  public  interface IDepartmentEntity : IAggregateRoot
    {
     
        public string Name { get; set; }
    }
}
