﻿using Data.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    class TaskRepo : ITaskRepo
    {
        private readonly DataContext _dataContext;

        TaskRepo(DataContext data)
        {
            _dataContext = data;
        }

        async Task<bool> CreateTaskAsync(UserTask task)
        {
            await _dataContext.Tasks.AddAsync(task);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        async Task<bool> UpdateTaskAsync(UserTask taskToUpdate)
        {
            _dataContext.Tasks.Update(taskToUpdate);

            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        async Task<bool> DeleteTaskAsync(Guid taskId)
        {
            var task = await _dataContext.Tasks.SingleOrDefaultAsync(t => t.Id == taskId);

            if (task == null)
                return false;

            _dataContext.Tasks.Remove(task);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        async Task<UserTask> GetTaskByIdAsync(Guid taskId)
        {
            var task = await _dataContext.Tasks.SingleOrDefaultAsync(t => t.Id == taskId);

            return task;
        }

        async Task<List<UserTask>> GetTasksAsync()
        {
            return await _dataContext.Tasks.ToListAsync();
        }
    }
}
