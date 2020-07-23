using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Services.Interfaces.RepoInterfaces
{
    public interface ITaskSQLRepo
    {
        Task<List<UserTask>> GetTasks();

        Task<UserTask> GetTaskById(Guid taskId);

        Task<bool> CreateTask(UserTask task);

        Task<bool> UpdateTask(UserTask taskToUpdate);

        Task<bool> DeleteTask(Guid taskId);
    }
}
