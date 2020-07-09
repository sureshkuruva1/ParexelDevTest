using System;
using System.Collections.Generic;

namespace ParexelDevTest.DataBase
{
    public partial class UserTask
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateDue { get; set; }
        public int? AssignedUserId { get; set; }
        public int? EscalationUserId { get; set; }

        public virtual UserInfo AssignedUser { get; set; }
        public virtual UserInfo EscalationUser { get; set; }
    }
}
