using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Abstraction.ServiceInterfaces
{
    public interface ITaskService
    {
        Task<List<TaskResponse>> GetTasksAsync();

        Task<TaskResponse> GetTaskByIdAsync(Guid taskId);

        Task<TaskResponse> CreateTaskAsync(CreateTaskRequest task);

        Task<TaskResponse> UpdateTaskAsync(Guid taskId, UpdateTaskRequest taskToUpdate);

        Task<bool> DeleteTaskAsync(Guid taskId);
    }
}
