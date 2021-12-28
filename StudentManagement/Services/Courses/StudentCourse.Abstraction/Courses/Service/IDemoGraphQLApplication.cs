

using StudentCourse.Abstraction.Courses.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;

namespace StudentCourse.Abstraction.Courses.Service
{
  public  interface IDemoGraphQLApplication
    {
     
        Task<CommandResult> Addcourse(AddCourse command,RequestContext context);
     
      

    


    }
}
