
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Messaging;

namespace StudentCourse.Abstraction.Courses.Models
{
   public class EntityId : ICommandData,IEventData
    {
        public Guid Id { get; set; }
        public Guid RootEntityId { get; set; }
    }
}
