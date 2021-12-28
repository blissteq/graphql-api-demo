
using StudentDepartment.Abstraction.StudentDepartment.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;

namespace StudentDepartment.Abstraction.StudentDepartment.Service
{
  public  interface IDemoGraphQLApplication
    {
      
        
        Task<CommandResult> AddDepartment(AddDepartment command, RequestContext context);
        Task<CommandResult> AddLecturer(AddLecturer command, RequestContext context);

        Task<CommandResult> RemoveDepartment(RemoveDepartment command, RequestContext context);
        Task<CommandResult> UpdateDepartment(UpdateDepartment command, RequestContext context);



    }
}
