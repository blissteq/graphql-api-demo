
using HotChocolate;
using HotChocolate.Resolvers;
using StudentCourse.Abstraction.Courses.Entities;
using StudentCourse.Abstraction.Courses.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourse.API.Courses.GrapgQL
{
    public class Query
    {
       
      

        public Task<List<ICourseEntity>> GetCoursesAsync(IResolverContext ctx) => ctx.Service<IDemoGraphQLQueryHandler>().GetAllCourses();

        


        
        
        public async Task<ICourseEntity> GetCourseAsync([Service] IDemoGraphQLQueryHandler _service, Guid id)
        {
            var course = await _service.GetCourse(id);
            return course;
        }

      





    }
}
