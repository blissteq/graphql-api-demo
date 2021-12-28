
using HotChocolate;
using HotChocolate.Resolvers;
using StudentDepartment.Abstraction.StudentDepartment.Entities;
using StudentDepartment.Abstraction.StudentDepartment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDepartment.API.GrapgQL
{
    public class Query
    {
       
     

        public Task<List<IDepartmentEntity>> GetDepartmentsAsync(IResolverContext ctx) => ctx.Service<IDemoGraphQLQueryHandler>().GetAllDepartments();



        public Task<List<ILecturerEntity>> GetLecturersAsync(IResolverContext ctx) => ctx.Service<IDemoGraphQLQueryHandler>().GetAllLecturers();


       
        public async Task<IDepartmentEntity> GetDepartmentAsync([Service] IDemoGraphQLQueryHandler _service, Guid id)
        {
            var department = await _service.GetDepartment(id);
            return department;
        }

        
     
        public async Task<ILecturerEntity> GetLecturerAsync([Service] IDemoGraphQLQueryHandler _service, Guid id)
        {
            var lecturer = await _service.GetLecturer(id);
            return lecturer;
        }





    }
}
