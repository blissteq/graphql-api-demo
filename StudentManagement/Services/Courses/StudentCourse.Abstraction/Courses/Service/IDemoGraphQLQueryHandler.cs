
using StudentCourse.Abstraction.Courses.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourse.Abstraction.Courses.Service
{
   public interface IDemoGraphQLQueryHandler
    {
    

        Task<ICourseEntity> GetCourse(Guid id);

        Task<List<ICourseEntity>> GetAllCourses();




    }
}
