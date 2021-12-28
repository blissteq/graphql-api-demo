
using StudentDetail.Core.Aggregates;
using StudentDetails.Abstraction.Models;
using StudentDetails.Abstraction.Repositories;
using StudentDetails.Abstraction.Service;
using StudentDetails.Abstraction.Student.Command;
using StudentDetails.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;
using ZA365Solutions.Platform.Common.Enums;

namespace StudentDetails.Core.Services
{
    public class StudentDetailsApplication : IStudentDetailsApplication
    {
        private readonly IStudentRepository _studentRepository;
     

        public StudentDetailsApplication(IStudentRepository repository)
        {
            _studentRepository = repository;
         
        }


        public async Task<CommandResult> AddStudent(AddStudent command, RequestContext context)
        {
            var entity = (StudentEntity)await _studentRepository.LoadAggregateAsync(Guid.Empty);

            var aggregate = new StudentAggregate(entity);
            var resourse = command.CommandData;
            resourse.Id = aggregate.Id;

            var commandResult = new CommandResult<StudentDTO>(aggregate.Id, resourse, true);

            var result = aggregate.Register(command.CommandData);
            if (result.IsValid)
            {
                await _studentRepository.SaveAggregateAsync(entity);
            }
            else
            {
                commandResult = new CommandResult<StudentDTO>(Guid.Empty, command.CommandData, false);
                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }

        public async Task<CommandResult> RemoveStudent(RemoveStudent command, RequestContext context)
        {

            var entity = (StudentEntity)await _studentRepository.LoadAggregateAsync(command.CommandData.Id);

            var aggregate = new StudentAggregate(entity);
            var commandResult = new CommandResult(aggregate.Id, true);


            aggregate.Delete();
            await _studentRepository.SaveAggregateAsync(entity);

            return commandResult;
        }

        public async Task<CommandResult> UpdateStudent(UpdateStudent command, RequestContext context)
        {

            var entity = (StudentEntity)await _studentRepository.LoadAggregateAsync(command.CommandData.Id);

            var aggregate = new StudentAggregate(entity);
            var commandResult = new CommandResult(aggregate.Id, true);

            var result = aggregate.Update(command.CommandData);

            if (result.IsValid)
            {

                await _studentRepository.SaveAggregateAsync(entity);

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
