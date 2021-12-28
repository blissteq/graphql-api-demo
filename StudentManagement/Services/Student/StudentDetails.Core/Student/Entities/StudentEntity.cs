

using StudentDetails.Abstraction.Student.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;

namespace StudentDetails.Core.Entities
{
    public class StudentEntity : IStudentEntity
    {
       
        public string Name { get ; set ; }
        public string Address { get ; set ; }
        public string Gender { get ; set ; }
        public Guid DepartmentId { get ; set ; }
        public string Level { get ; set ; }

        public DateTime LastProcessedEventTime =>DateTime.Now;

        public bool IsDeleted { get ; set ; }
        public bool IsNew { get ; set ; }
        public Guid Id {get ; set ; }
    }
}
