

using StudentDepartment.Abstraction.StudentDepartment.Command;
using StudentDepartment.Abstraction.StudentDepartment.Models;
using StudentDepartment.Abstraction.StudentDepartment.Repositories;
using StudentDepartment.Abstraction.StudentDepartment.Service;
using StudentDepartment.Core.Aggregates;
using StudentDepartment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;
using ZA365Solutions.Platform.Common.Enums;

namespace StudentDepartment.Core.Services
{
    public class DemoGraphQLApplication : IDemoGraphQLApplication
    {
      
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILecturerRepository _lecturerRepository;
 

        public DemoGraphQLApplication(IDepartmentRepository departmentRepository,ILecturerRepository lecturerRepository)
        {
          
            _departmentRepository = departmentRepository;
            _lecturerRepository = lecturerRepository;
          
        }

       
        public async Task<CommandResult> AddDepartment(AddDepartment command, RequestContext context)
        {
            var entity = (DepartmentEntity)await _departmentRepository.LoadAggregateAsync(Guid.Empty);

            var aggregate = new DepartmentAggregate(entity);
            var resourse = command.CommandData;
            resourse.Id = aggregate.Id;

            var commandResult = new CommandResult<Department>(aggregate.Id, resourse, true);

            var result = aggregate.Register(command.CommandData);
            if (result.IsValid)
            {
                await _departmentRepository.SaveAggregateAsync(entity);
            }
            else
            {
                commandResult = new CommandResult<Department>(Guid.Empty, command.CommandData, false);
                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }

       

        public async Task<CommandResult> AddLecturer(AddLecturer command, RequestContext context)
        {
            var entity = (LecturerEntity)await _lecturerRepository.LoadAggregateAsync(Guid.Empty);

            var aggregate = new LecturerAggregate(entity);
            var resourse = command.CommandData;
            resourse.Id = aggregate.Id;

            var commandResult = new CommandResult<Lecturer>(aggregate.Id, resourse, true);

            var result = aggregate.Register(command.CommandData);
            if (result.IsValid)
            {
                await _lecturerRepository.SaveAggregateAsync(entity);
            }
            else
            {
                commandResult = new CommandResult<Lecturer>(Guid.Empty, command.CommandData, false);
                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }

        
        public async Task<CommandResult> RemoveDepartment(RemoveDepartment command, RequestContext context)
        {
            
            var entity = (DepartmentEntity)await _departmentRepository.LoadAggregateAsync(command.CommandData.Id);

            var aggregate = new DepartmentAggregate(entity);
            var commandResult = new CommandResult(aggregate.Id, true);

   
            aggregate.Delete();
            await _departmentRepository.SaveAggregateAsync(entity);
        
            return commandResult;
        }

        public async Task<CommandResult> UpdateDepartment(UpdateDepartment command, RequestContext context)
        {
            
            var entity = (DepartmentEntity)await _departmentRepository.LoadAggregateAsync(command.CommandData.Id);

            var aggregate = new DepartmentAggregate(entity);
            var commandResult = new CommandResult(aggregate.Id, true);

            var result = aggregate.Update(command.CommandData);

            if (result.IsValid)
            {
           
                await _departmentRepository. SaveAggregateAsync(entity);

            }
            else
            {
                commandResult = new CommandResult(Guid.Empty, false);
             
                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }
    }
}
