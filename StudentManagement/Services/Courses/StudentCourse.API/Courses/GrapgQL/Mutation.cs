


using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;
using Microsoft.AspNetCore.Http;
using ZA365Solutions.Platform.Common.Enums;


using StudentCourse.API.Helpers;
using StudentCourse.Abstraction.Courses.Service;
using StudentCourse.Abstraction.Courses.Repositories;
using StudentCourse.Abstraction.Courses.Models;
using StudentCourse.Abstraction.Courses.Command;

namespace StudentCourse.API.Courses.GrapgQL
{
    public class Mutation
    {
        private readonly IDemoGraphQLApplication _application;
        public Mutation(IDemoGraphQLApplication application)
        {
            _application = application;
        }
        
     

        public async Task<Course> AddCourse([Service] ICourseRepository _repo,Guid id,string name,Guid departmentId,Guid lecturerId,string level)
        {
            RequestContext context = SecurityContextHelper.GetCurrentRequestContext();
            var course = new Course
            {
                Id = id,
                Name = name,
                DepartmentId = departmentId,
                LecturerId = lecturerId,
                Level = level
           
            };
            var command = new AddCourse
            {
                CommandData = course,
                UserId = context.UserId,
                UserEmail = context.UserEmail,
                SubscriptionId = context.SubscriptionId,
            };
            await _application.Addcourse(command,context);
            return course;
        }


       




           
        


    }
}
