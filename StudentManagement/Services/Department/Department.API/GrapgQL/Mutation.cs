

using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;
using Microsoft.AspNetCore.Http;
using ZA365Solutions.Platform.Common.Enums;
using ZA365Solutions.Platform.Common;
using StudentDepartment.Abstraction.StudentDepartment.Service;
using StudentDepartment.Abstraction.StudentDepartment.Models;
using StudentDepartment.Abstraction.StudentDepartment.Repositories;
using StudentDepartment.API.GrapgQL.Helpers;
using StudentDepartment.Abstraction.StudentDepartment.Command;

namespace StudentDepartment.API.GrapgQL
{
    public class Mutation
    {
        private readonly IDemoGraphQLApplication _application;
        public Mutation(IDemoGraphQLApplication application)
        {
            _application = application;
        }
      

        public async Task<Department> AddDepartment([Service] IDepartmentRepository _repo, Guid id, string name)
        {
            RequestContext context = SecurityContextHelper.GetCurrentRequestContext();
            var department = new Department()
            {
                Id = id,
                Name = name

            };

            var command = new AddDepartment
            {
                CommandData = department,
                UserId = context.UserId,
                UserEmail = context.UserEmail,
                SubscriptionId = context.SubscriptionId,
            };
             await _application.AddDepartment(command,context);
            return department;
        }

        public async Task<Lecturer> AddLecturer([Service] ILecturerRepository _repo,Guid id,string name,Guid departmentId,Guid courseId)
        {
            RequestContext context = SecurityContextHelper.GetCurrentRequestContext();
            var lecturer = new Lecturer
            {
                Id = id,
                Name = name,
                CourseId = courseId,
                DepartmentId = departmentId,
            };
            var command = new AddLecturer
            {
                CommandData = lecturer,
                UserId = context.UserId,
                UserEmail = context.UserEmail,
                SubscriptionId = context.SubscriptionId,
            };
             await _application.AddLecturer(command,context);
            return lecturer;
        }

        

        public async Task<Department> UpdateStudent([Service] IDepartmentRepository repository, Guid id, string name)
        {
            RequestContext context = SecurityContextHelper.GetCurrentRequestContext();
            var student = new Department()
            {
                Id = id,
                Name = name,
               

            };
            var command = new UpdateDepartment
            {
                CommandData = student,
                UserId = context.UserId,
                UserEmail = context.UserEmail,
                SubscriptionId = context.SubscriptionId,

            };
            await _application.UpdateDepartment(command,context);

            return student;




        }

        public async Task  DeleteDepartment([Service] IDepartmentRepository repository,Guid id)
        {
            RequestContext context = SecurityContextHelper.GetCurrentRequestContext();
            var deleteEntity = new EntityId { Id = id };
            var command = new RemoveDepartment
            {
                CommandData = deleteEntity,
                UserId = context.UserId,
                UserEmail = context.UserEmail,
                SubscriptionId = context.SubscriptionId
            };
          
           var commandResult =    await _application.RemoveDepartment(command, context);

           






           
        }


    }
}
