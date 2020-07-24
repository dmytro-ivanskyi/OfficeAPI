using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data.Entities;
using WebAPI.Services.Interfaces.RepoInterfaces;

namespace WebAPI.Data.Repositories
{
    public class TaskSQLRepo : ITaskSQLRepo
    {
        public Task<bool> CreateTask(Entities.UserTask task)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTask(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public Task<Task> GetTaskById(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Task>> GetTasks()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTask(Entities.UserTask taskToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
