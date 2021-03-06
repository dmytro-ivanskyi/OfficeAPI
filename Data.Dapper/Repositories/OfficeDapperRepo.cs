﻿using Dapper;
using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Dapper.Repositories
{
    public class OfficeDapperRepo : IOfficeRepo
    {
        private readonly SqlServerConnectionProvider _provider;

        public OfficeDapperRepo(SqlServerConnectionProvider provider)
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

        public async Task<bool> CreateOfficeAsync(Office office)
        {
            var sql = "INSERT INTO Offices(Id, Name) VALUES (@Id, @Name);";
            using (var connection = Context)
            {
                office.Id = Guid.NewGuid();
                var affectedRows = await connection.ExecuteAsync(sql, office);
                return affectedRows == 1;
            }
        }

        public async Task<bool> DeleteOfficeAsync(Guid officeId)
        {
            var sql = "DELETE FROM Offices WHERE Id = @Id";
            using (var connection = Context)
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = officeId });
                return affectedRows == 1;
            }
        }

        public async Task<Office> GetOfficeByIdAsync(Guid officeId)
        {
            var sql = "SELECT * FROM Offices WHERE Id = @Id;";
            using (var connection = Context)
            {
                var result = await connection.QueryFirstAsync<Office>(sql, new { Id = officeId });
                return result;
            }
        }

        public async Task<Office> GetOfficeByIdWithUsersAsync(Guid officeId)
        {

            //var sql = "SELECT Id, FirstName, LastName, Age FROM Users WHERE Users.OfficeId = @Id";
            //using (var connection = Context)
            //{
            //    var office = await GetOfficeByIdAsync(officeId);
            //    var users = await connection.QueryAsync<User>(sql, new { Id = officeId });
            //    office.Users = users.ToList();
            //    return office;
            //}
            var sql = "SELECT o.Id, o.[Name], u.Id, u.FirstName, u.LastName, u.Age, u.OfficeId  FROM Offices as o JOIN Users AS u ON o.Id = u.OfficeId WHERE u.OfficeId = @Id";
            using (var connection = Context)
            {
                var queryParams = new { Id = officeId };
                var result = await connection.QueryAsync<Office, User, Office>(sql, (office, user) =>
                {
                    office.Users.Add(user);
                    return office;
                }, queryParams, splitOn: "Id");

                var office = new Office();
               
                if (result.Count() == 0)
                {
                    office = await GetOfficeByIdAsync(officeId);
                }
                else
                {
                    office.Id = result.First().Id;
                    office.Name = result.First().Name;
                    foreach (var o in result)
                    {
                        office.Users.Add(o.Users.FirstOrDefault());
                    }
                }  

                return office;
            }
        }

        public async Task<List<Office>> GetOfficesAsync()
        {
            var sql = "SELECT * FROM Offices;";
            using (var connection = Context)
            {
                var result = await connection.QueryAsync<Office>(sql);
                return result.ToList();
            }
        }

        public async Task<bool> UpdateOfficeAsync(Office officeToUpdate)
        {
            var sql = "UPDATE Offices SET Name = @Name WHERE Id = @Id;";
            using (var connection = Context)
            {
                var affectedRows = await connection.ExecuteAsync(sql, officeToUpdate);
                return affectedRows == 1;
            }
        }
    }
}