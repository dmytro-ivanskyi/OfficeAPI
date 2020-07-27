using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebAPI.Contracts.V1.Requests;
using WebAPI.Contracts.V1.Responses;
using WebAPI.Data.Entities;
using WebAPI.Services.Interfaces.RepoInterfaces;

namespace WebAPI.Data.Repositories
{
    public class TaskSQLRepo : ITaskSQLRepo
    {
        private readonly DataContext _dataContext;
        public TaskSQLRepo(DataContext data)
        {
            _dataContext = data;
        }
        public async Task<bool> CreateTask(UserTask task)
        {
            await _dataContext.Tasks.AddAsync(task);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateTask(UserTask taskToUpdate)
        {
            _dataContext.Tasks.Update(taskToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteTask(Guid taskId)
        {
            var task = await _dataContext.Tasks.SingleOrDefaultAsync(t => t.Id == taskId);
            if (task == null)
                return false;

            _dataContext.Tasks.Remove(task);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<UserTaskResponse> GetTaskById(Guid taskId)
        {
            var task = await _dataContext.Tasks.SingleOrDefaultAsync(t => t.Id == taskId);

            return new UserTaskResponse
            {
                Id = task.Id,
                Description = task.Description,
                UserId = task.UserId
            };
        }

        public async Task<List<UserTaskResponse>> GetTasks()
        {
            return await _dataContext.Tasks
                .Select(x => new UserTaskResponse 
                {
                    Id = x.Id,
                    Description = x.Description,
                    UserId = x.UserId
                })
                .ToListAsync();
        }
    }
}
