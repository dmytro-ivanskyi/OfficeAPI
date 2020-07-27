using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Contracts.V1.Requests;
using WebAPI.Contracts.V1.Responses;
using WebAPI.Data.Entities;
using WebAPI.Services.Interfaces.RepoInterfaces;
using WebAPI.Services.Interfaces.ServiceInterfaces;

namespace WebAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskSQLRepo _taskSQLRepo;

        public TaskService(ITaskSQLRepo repo)
        {
            _taskSQLRepo = repo;
        }

        public async Task<bool> CreateTask(UserTask task)
        {
            return await _taskSQLRepo.CreateTask(task);
        }

        public async Task<bool> DeleteTask(Guid taskId)
        {
            return await _taskSQLRepo.DeleteTask(taskId);
        }

        public async Task<UserTaskResponse> GetTaskById(Guid taskId)
        {
            return await _taskSQLRepo.GetTaskById(taskId);
        }

        public async Task<List<UserTaskResponse>> GetTasks()
        {
            return await _taskSQLRepo.GetTasks();
        }

        public async Task<bool> UpdateTask(UserTask taskToUpdate)
        {
            return await _taskSQLRepo.UpdateTask(taskToUpdate);
        }
    }
}
