using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces.RepoInterfaces
{
    public interface ITaskRepo
    {
        Task<List<UserTask>> GetTasks();

        Task<UserTask> GetTaskById(Guid taskId);

        Task<bool> CreateTask(UserTask task);

        Task<bool> UpdateTask(UserTask taskToUpdate);

        Task<bool> DeleteTask(Guid taskId);
    }
}
