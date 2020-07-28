using Data.Abstraction.Interfaces.RepoInterfaces;
using Data.Abstraction.Interfaces.ServiceInterfaces;
using Data.EF.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Abstraction.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepo _taskRepo;

        public TaskService(ITaskRepo repo)
        {
            _taskRepo = repo;
        }

        public async Task<bool> CreateTaskAsync(UserTask task)
        {
            return await _taskRepo.CreateTaskAsync(task);
        }

        public async Task<bool> DeleteTaskAsync(Guid taskId)
        {
            return await _taskRepo.DeleteTaskAsync(taskId);
        }

        public async Task<UserTask> GetTaskByIdAsync(Guid taskId)
        {
            return await _taskRepo.GetTaskByIdAsync(taskId);
        }

        public async Task<List<UserTask>> GetTasksAsync()
        {
            return await _taskRepo.GetTasksAsync();
        }

        public async Task<bool> UpdateTaskAsync(UserTask taskToUpdate)
        {
            return await _taskRepo.UpdateTaskAsync(taskToUpdate);
        }
    }
}
