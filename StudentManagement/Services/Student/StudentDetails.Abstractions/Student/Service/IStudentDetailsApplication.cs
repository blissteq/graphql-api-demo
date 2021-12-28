
using StudentDetails.Abstraction.Student.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;

namespace StudentDetails.Abstraction.Service
{
  public  interface IStudentDetailsApplication
    {
        Task<CommandResult> AddStudent(AddStudent command,RequestContext context);

        Task<CommandResult> RemoveStudent(RemoveStudent command, RequestContext context);
        Task<CommandResult> UpdateStudent(UpdateStudent command, RequestContext context);



    }
}
