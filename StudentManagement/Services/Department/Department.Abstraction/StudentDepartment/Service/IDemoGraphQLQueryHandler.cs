
using StudentDepartment.Abstraction.StudentDepartment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDepartment.Abstraction.StudentDepartment.Service
{
   public interface IDemoGraphQLQueryHandler
    {


        Task<IDepartmentEntity> GetDepartment(Guid id);

        Task<List<IDepartmentEntity>> GetAllDepartments();

 

        Task<ILecturerEntity> GetLecturer(Guid id);
        Task<List<ILecturerEntity>> GetAllLecturers();


    }
}
