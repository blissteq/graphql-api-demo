

using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using ZA365Solutions.Platform.Common.Enums;
using ZA365Solutions.Platform.Common;
using StudentDetails.Abstraction.Models;
using StudentDetails.Abstraction.Repositories;
using StudentDetails.API.Helpers;
using StudentDetails.Abstraction.Student.Command;
using StudentDetails.Abstraction.Service;
using Microsoft.AspNetCore.Mvc;

namespace StudentDetails.API.GrapgQL
{
    public class Mutation
    {
        private readonly IStudentDetailsApplication _application;
        public Mutation(IStudentDetailsApplication application)
        {
            _application = application;
        }
        public async Task <StudentDTO> AddStudent([Service]IStudentRepository repository,Guid id, string name, string address,string gender,Guid departmentId,string level)
        {
            RequestContext context = SecurityContextHelper.GetCurrentRequestContext();
            var student = new StudentDTO()
            {
                Id = id,
                Name = name,
                Address = address,
                Gender = gender,
                DepartmentId = departmentId,
                Level = level

            };
            var command = new AddStudent
            {
                CommandData = student,
                UserId = context.UserId,
                UserEmail = context.UserEmail,
                SubscriptionId = context.SubscriptionId,

            };
             await _application.AddStudent(command,context);

            return student;




        }

      

        public async Task<StudentDTO> UpdateStudent([Service] IStudentRepository repository, Guid id, string? name, string? address, string? gender, Guid departmentId, string ? level)
        {
            RequestContext context = SecurityContextHelper.GetCurrentRequestContext();
            var student = new StudentDTO()
            {
                Id = id,
                Name = name,
                Address = address,
                Gender = gender,
                DepartmentId = departmentId,
                Level = level

            };
            var command = new UpdateStudent
            {
                CommandData = student,
                UserId = context.UserId,
                UserEmail = context.UserEmail,
                SubscriptionId = context.SubscriptionId,

            };
            await _application.UpdateStudent(command,context);

            return student;




        }

        public async Task<CommandResult> DeleteStudent(Guid id)
        {
            RequestContext context = SecurityContextHelper.GetCurrentRequestContext();
            var deleteEntity = new EntityId { Id = id };
            var command = new RemoveStudent
            {
                CommandData = deleteEntity,
                UserId = context.UserId,
                UserEmail = context.UserEmail,
                SubscriptionId = context.SubscriptionId
            };
            var commandResult = new CommandResult(deleteEntity.Id, true);
            commandResult =    await _application.RemoveStudent(command, context);

          
                return commandResult;
       
           
        }

     
    }
}
