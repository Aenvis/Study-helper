using StudyHelper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.Domain.Queries
{
    public interface IGetTodoTasksQuery
    {
        Task<IEnumerable<TodoTask>> Execute();
    }
}
