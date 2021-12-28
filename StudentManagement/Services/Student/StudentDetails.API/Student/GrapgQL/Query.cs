
using HotChocolate;
using HotChocolate.Resolvers;
using StudentDetails.Abstraction.Service;
using StudentDetails.Abstraction.Student.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDetails.API.GrapgQL
{
    public class Query
    {
       
        public Task<List<IStudentEntity>> GetStudentsAsync(IResolverContext ctx) => ctx.Service<IStudentDetailsQueryHandler>().GetAllStudents();




        public async Task<IStudentEntity> GetStudentAsync([Service] IStudentDetailsQueryHandler _service, Guid id)
        {
            var student = await _service.GetStudent(id);
            return student;
        }

      

        





    }
}
