
using StudentDepartment.Abstraction.StudentDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Messaging;

namespace StudentDepartment.Abstraction.StudentDepartment.Command
{
    public class UpdateDepartment: ICommand<Department>
    {
       public UpdateDepartment()
        {
            CommandId = Guid.NewGuid();
        }
        public string UserId { get; set; }
        public Guid SubscriptionId { get; set; }
        public string UserEmail { get; set; }
        public Guid CommandId { get; }
        public string Name => GetType().Name.ToLower();
        public Department CommandData { get; set; }
        public DateTime CommandTime { get; set; }
    }
}

