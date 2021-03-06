﻿using Data.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Abstraction.RepoInterfaces
{
    public interface ITaskRepo
    {
        Task<List<UserTask>> GetTasksAsync();

        Task<UserTask> GetTaskByIdAsync(Guid taskId);

        Task<bool> CreateTaskAsync(UserTask task);

        Task<bool> UpdateTaskAsync(UserTask taskToUpdate);

        Task<bool> DeleteTaskAsync(Guid taskId);
    }
}
