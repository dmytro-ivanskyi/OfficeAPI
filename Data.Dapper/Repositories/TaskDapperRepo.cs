using Dapper;
using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Dapper.Repositories
{
    public class TaskDapperRepo : ITaskRepo
    {
        private readonly SqlServerConnectionProvider _provider;

        public TaskDapperRepo(SqlServerConnectionProvider provider)
        {
            _provider = provider;
        }

        protected IDbConnection Context
        {
            get
            {
                var connection = _provider.GetDbConnection();
                connection.Open();
                return connection;
            }
        }

        public async Task<bool> CreateTaskAsync(UserTask task)
        {
            var sql = "INSERT INTO Tasks (Id, Description, UserId) VALUES (@Id, @Description, @UserId);";
            using (var connection = Context)
            {
                task.Id = Guid.NewGuid();
                var affectedRows = await connection.ExecuteAsync(sql, task);
                return affectedRows == 1;
            }
        }

        public async Task<bool> DeleteTaskAsync(Guid taskId)
        {
            var sql = "DELETE FROM Tasks WHERE Id = @Id";
            using (var connection = Context)
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = taskId });
                return affectedRows == 1;
            }
        }

        public async Task<UserTask> GetTaskByIdAsync(Guid taskId)
        {
            var sql = "SELECT * FROM Tasks WHERE Id = @Id";
            using (var connection = Context)
            {
                var task = await connection.QueryFirstAsync<UserTask>(sql, new { Id = taskId });
                return task;
            }
        }

        public async Task<List<UserTask>> GetTasksAsync()
        {
            var sql = "SELECT * FROM Tasks;";
            using (var connection = Context)
            {
                var result = await connection.QueryAsync<UserTask>(sql);
                return result.ToList();
            }
        }

        public async Task<bool> UpdateTaskAsync(UserTask taskToUpdate)
        {
            var sql = "UPDATE Tasks SET Description = @Description, UserId = @UserId WHERE Id = @Id;";
            using (var connection = Context)
            {
                var affectedRows = await connection.ExecuteAsync(sql, taskToUpdate);
                return affectedRows == 1;
            }
        }
    }
}
