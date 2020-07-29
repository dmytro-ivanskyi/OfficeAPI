using AutoMapper;
using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;
using Service.Abstraction.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Abstraction.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepo _taskRepo;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepo repo, IMapper mapper)
        {
            _taskRepo = repo;
            _mapper = mapper;
        }

        public async Task<TaskResponse> CreateTaskAsync(CreateTaskRequest task)
        {
            var newTask = _mapper.Map<UserTask>(task);

            var created = await _taskRepo.CreateTaskAsync(newTask);

            if (!created)
                return null;

            return await GetTaskByIdAsync(newTask.Id);
        }

        public async Task<bool> DeleteTaskAsync(Guid taskId)
        {
            return await _taskRepo.DeleteTaskAsync(taskId);
        }

        public async Task<TaskResponse> GetTaskByIdAsync(Guid taskId)
        {
            var task = await _taskRepo.GetTaskByIdAsync(taskId);

            return _mapper.Map<TaskResponse>(task); 
        }

        public async Task<List<TaskResponse>> GetTasksAsync()
        {
            var tasks = await _taskRepo.GetTasksAsync();

            return _mapper.Map<List<TaskResponse>>(tasks);
        }

        public async Task<TaskResponse> UpdateTaskAsync(Guid taskId, UpdateTaskRequest taskToUpdate)
        {
            var updatedTask = _mapper.Map<UserTask>(taskToUpdate);
            updatedTask.Id = taskId;

            var updated = await _taskRepo.UpdateTaskAsync(updatedTask);

            if (updated)
                return await GetTaskByIdAsync(taskId);

            return null;
        }
    }
}
