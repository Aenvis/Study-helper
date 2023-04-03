using StudyHelper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.Domain.Commands
{
    public interface ICreateTodoTaskCommand
    {
        Task Exectute(TodoTask task);
    }
}
