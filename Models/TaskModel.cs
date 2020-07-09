using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParexelDevTest.Models
{
    public class TaskModel : BaseTaskModel
    {
        
        public string AssignedUser { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateDue { get; set; }

        public string EscalationUser {get;set;}

    }
}
