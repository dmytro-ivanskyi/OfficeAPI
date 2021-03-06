﻿using Dapper;
using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Dapper.Repositories
{
    public class UserDapperRepo : IUserRepo
    {
        private readonly SqlServerConnectionProvider _provider;

        public UserDapperRepo(SqlServerConnectionProvider provider)
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

        public async Task<bool> CreateUserAsync(User user)
        {
            var sql = "INSERT INTO Users (Id, FirstName, LastName, Age, OfficeId) VALUES (@Id, @FirstName, @LastName, @Age, @OfficeId);";
            using (var connection = Context)
            {
                user.Id = Guid.NewGuid();
                var affectedRows = await connection.ExecuteAsync(sql, user);
                return affectedRows == 1;
            }
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var sql = "DELETE FROM Users WHERE Id = @Id";
            using (var connection = Context)
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = userId });
                return affectedRows == 1;
            }
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            var sql = "SELECT * FROM Users WHERE Id = @Id";
            var sql_tasks = " SELECT Id, Description FROM Tasks WHERE UserID = @Id";
            var sql_perm = " SELECT PermissionId FROM UserPermissions WHERE UserID = @Id";
            using (var connection = Context)
            {
                var user = await connection.QueryFirstAsync<User>(sql, new { Id = userId });
                user.Tasks = (await connection.QueryAsync<UserTask>(sql_tasks, new { Id = userId })).ToList();
                user.Permissions = (await connection.QueryAsync<UserPermission>(sql_perm, new { Id = userId })).ToList();

                return user;
            }
            //var sql = "SELECT * FROM Users u JOIN Tasks ON Tasks.UserId = u.Id WHERE u.Id = @Id";
            //using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            //{
            //    connection.Open();
            //    var user = await connection.QueryFirstAsync<User>(sql, new { Id = userId });
            //    return user;
            //}
        }

        public async Task<User> GetUserByIdShortAsync(Guid userId)
        {
            var sql = "SELECT Id, FirstName, LastName, Age FROM Users WHERE Id = @Id;";
            using (var connection = Context)
            {
                var result = await connection.QueryFirstAsync<User>(sql, new { Id = userId });
                return result;
            }
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var sql = "SELECT * FROM Users;";
            using (var connection = Context)
            {
                var result = await connection.QueryAsync<User>(sql);
                return result.ToList();
            }
        }

        public async Task<bool> UpdateUserAsync(User userToUpdate)
        {
            var sql = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Age = @Age, OfficeId = @OfficeId WHERE Id = @Id;";
            using (var connection = Context)
            {
                var affectedRows = await connection.ExecuteAsync(sql, userToUpdate);
                return affectedRows == 1;
            }
        }
    }
}
