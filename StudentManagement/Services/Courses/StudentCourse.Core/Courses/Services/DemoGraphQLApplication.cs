
using StudentCourse.Abstraction.Courses.Command;
using StudentCourse.Abstraction.Courses.Models;
using StudentCourse.Abstraction.Courses.Repositories;
using StudentCourse.Abstraction.Courses.Service;
using StudentCourse.Core.Courses.Aggregates;
using StudentCourse.Core.Courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;
using ZA365Solutions.Platform.Common.Enums;

namespace StudentCourse.Core.Courses.Services
{
    public class DemoGraphQLApplication : IDemoGraphQLApplication
    {
     
        
        private readonly ICourseRepository _courseRepository;

        public DemoGraphQLApplication(ICourseRepository courseRepository)
        {
           
          
            _courseRepository = courseRepository;
        }

        public async Task<CommandResult> Addcourse(AddCourse command, RequestContext context)
        {
            var entity = (CourseEntity)await _courseRepository.LoadAggregateAsync(Guid.Empty);

            var aggregate = new CourseAggregate(entity);
            var resourse = command.CommandData;
            resourse.Id = aggregate.Id;

            var commandResult = new CommandResult<Course>(aggregate.Id, resourse, true);

            var result = aggregate.Register(command.CommandData);
            if (result.IsValid)
            {
                await _courseRepository.SaveAggregateAsync(entity);
            }
            else
            {
                commandResult = new CommandResult<Course>(Guid.Empty, command.CommandData, false);
                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }

        
       

   

       
       
    }
}
