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

        Task<bool> CreateTaskAsync(TaskResponse task);

        Task<bool> UpdateTaskAsync(TaskResponse taskToUpdate);

        Task<bool> DeleteTaskAsync(Guid taskId);
    }
}
