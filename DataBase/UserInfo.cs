using System;
using System.Collections.Generic;

namespace ParexelDevTest.DataBase
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            UserTaskAssignedUser = new HashSet<UserTask>();
            UserTaskEscalationUser = new HashSet<UserTask>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<UserTask> UserTaskAssignedUser { get; set; }
        public virtual ICollection<UserTask> UserTaskEscalationUser { get; set; }
    }
}
