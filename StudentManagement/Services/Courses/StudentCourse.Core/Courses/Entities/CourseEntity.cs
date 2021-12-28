using StudentCourse.Abstraction.Courses.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourse.Core.Courses.Entities
{
    public class CourseEntity : ICourseEntity
    {
        public string Level { get ; set ; }
        public string Name { get ; set ; }
        public Guid DepartmentId { get ; set ; }
        public Guid LecturerId { get ; set ; }

        public DateTime LastProcessedEventTime => DateTime.Now;

        public Guid Id { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public bool IsNew { get; set ; }
    }
}
