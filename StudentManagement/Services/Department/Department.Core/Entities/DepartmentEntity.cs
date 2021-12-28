
using StudentDepartment.Abstraction.StudentDepartment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDepartment.Core.Entities
{
    public class DepartmentEntity : IDepartmentEntity
    {
        public string Name { get ; set ; }

        public DateTime LastProcessedEventTime => DateTime.Now;

        public Guid Id { get ; set; }
        public bool IsDeleted { get; set ; }
        public bool IsNew { get ; set ; }
    }
}
