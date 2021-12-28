
using StudentDepartment.Abstraction.StudentDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Messaging;

namespace StudentDepartment.Abstraction.StudentDepartment.Command
{
   public class AddLecturer :ICommand<Lecturer>
    {
        public AddLecturer()
        {
            CommandId = Guid.NewGuid();
            Name = GetType().Name.ToLower();
            CommandTime = DateTime.Now;
        }
        public string UserId { get; set; }
        public Guid SubscriptionId { get; set; }
        public string UserEmail { get; set; }
        public DateTime CommandTime { get; set; }
        public Guid CommandId { get; set; }
        public Lecturer CommandData { get; set; }
        public string Name { get; set; }

    }
}
