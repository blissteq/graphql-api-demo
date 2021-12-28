
using StudentCourse.Abstraction.Courses.Entities;
using StudentCourse.Abstraction.Courses.Repositories;
using StudentCourse.Abstraction.Courses.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;

namespace StudentCourse.Core.Courses.Services
{
    public class DemoGraphQLQueryHandler : IDemoGraphQLQueryHandler
    {
      
        private ICourseRepository _courseRepository;
       
        public DemoGraphQLQueryHandler(ICourseRepository courseRepository)
        {
            
            
            _courseRepository = courseRepository;
        }

     

        

       
       
        public async Task<ICourseEntity> GetCourse(Guid id)
        {
            return await _courseRepository.LoadModelAsync(id);
        }

        public async Task<List<ICourseEntity>> GetAllCourses()
        {
            var search = new List<SearchParameter> { new SearchParameter { } };
            var courses = await _courseRepository.FindModelsAsync(search);
            return courses.ToList();
        }

    }
}
