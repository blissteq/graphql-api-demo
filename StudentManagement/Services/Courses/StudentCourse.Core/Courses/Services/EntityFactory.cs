
using StudentCourse.Abstraction.Courses.Entities;
using StudentCourse.Core.Courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourse.Core.Courses.Services
{
  public static class EntityFactory
    {
      

       

     

        public static ICourseEntity CreateCourse()
        {
            return new CourseEntity()
            {
                IsNew = true,
                Id = Guid.NewGuid()
            };
        }
    }
}
