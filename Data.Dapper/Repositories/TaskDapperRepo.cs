using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Dapper.Repositories
{
    public class TaskDapperRepo : ITaskRepo
    {
        public Task<bool> CreateTaskAsync(UserTask task)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTaskAsync(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public Task<UserTask> GetTaskByIdAsync(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserTask>> GetTasksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTaskAsync(UserTask taskToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
