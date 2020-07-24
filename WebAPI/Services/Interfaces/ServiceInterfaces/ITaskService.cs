using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Services.Interfaces.ServiceInterfaces
{
    public interface ITaskService
    {
        Task<List<Task>> GetTasks();

        Task<Task> GetTaskById(Guid taskId);

        Task<bool> CreateTask(Data.Entities.UserTask task);

        Task<bool> UpdateTask(Data.Entities.UserTask taskToUpdate);

        Task<bool> DeleteTask(Guid taskId);
    }
}
