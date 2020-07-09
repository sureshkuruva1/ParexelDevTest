using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParexelDevTest.DataBase.Interfaces
{
    public interface ITask
    {
        int AddTask(Task task);
        int DeleteTask(int TaskId);

    }
}
