using StudyHelper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.Domain.Commands
{
    public interface IUpdateTodoTaskCommand
    {
        Task Exectute(TodoTask task);
    }
}
