

using StudentDetails.Abstraction.Student.Entities;
using StudentDetails.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetails.Core.Services
{
  public static class EntityFactory
    {
        public static IStudentEntity CreateStudent()
        {
            return new StudentEntity()
            {
                IsNew = true,
                Id = Guid.NewGuid()
            };
        }

        
    }
}
