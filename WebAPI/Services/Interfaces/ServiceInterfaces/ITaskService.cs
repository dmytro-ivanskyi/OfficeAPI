using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Contracts.V1.Responses;
using WebAPI.Data.Entities;

namespace WebAPI.Services.Interfaces.ServiceInterfaces
{
    public interface ITaskService
    {
        Task<List<UserTaskResponse>> GetTasks();

        Task<UserTaskResponse> GetTaskById(Guid taskId);

        Task<bool> CreateTask(UserTask task);

        Task<bool> UpdateTask(UserTask taskToUpdate);

        Task<bool> DeleteTask(Guid taskId);
    }
}
