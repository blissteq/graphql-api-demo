
using StudentDepartment.Abstraction.StudentDepartment.Entities;
using StudentDepartment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDepartment.Core.Services
{
  public static class EntityFactory
    {
        

        public static IDepartmentEntity CreateDepartment()
        {
            return new DepartmentEntity()
            {
                IsNew = true,
                Id = Guid.NewGuid()
            };
        }

        public static ILecturerEntity CreateLecturer()
        {
            return new LecturerEntity()
            {
                IsNew = true,
                Id = Guid.NewGuid()
            };
        }

    }
}
