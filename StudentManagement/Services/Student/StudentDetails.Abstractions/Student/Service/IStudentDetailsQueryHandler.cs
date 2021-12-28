
using StudentDetails.Abstraction.Student.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetails.Abstraction.Service
{
   public interface IStudentDetailsQueryHandler
    {
        Task<IStudentEntity> GetStudent(Guid id);

        Task<List<IStudentEntity>> GetAllStudents();

     


    }
}
