using Dapper;
using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Dapper.Repositories
{
    public class OfficeDapperRepo : IOfficeRepo
    {
        private readonly IConfiguration _configuration;

        public OfficeDapperRepo(IConfiguration configuration)
        {
            _configuration = configuration; ;
        }

        public async Task<bool> CreateOfficeAsync(Office office)
        {
            var sql = "INSERT INTO Offices(Id, Name) VALUES (@Id, @Name);";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                office.Id = Guid.NewGuid();
                var affectedRows = await connection.ExecuteAsync(sql, office);
                return affectedRows == 1;
            }
        }

        public async Task<bool> DeleteOfficeAsync(Guid officeId)
        {
            var sql = "DELETE FROM Offices WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = officeId });
                return affectedRows == 1;
            }
        }

        public async Task<Office> GetOfficeByIdAsync(Guid officeId)
        {
            var sql = "SELECT * FROM Offices WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Office>(sql, new { Id = officeId });
                return result.FirstOrDefault();
            }
        }

        public async Task<Office> GetOfficeByIdWithUsersAsync(Guid officeId)
        {
            
            var sql = "SELECT Id, FirstName, LastName, Age FROM Users WHERE Users.OfficeId = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var office = await GetOfficeByIdAsync(officeId);
                connection.Open();
                var users = await connection.QueryAsync<User>(sql, new { Id = officeId });
                office.Users = users.ToList();
                return office;
            }
        }

        public async Task<List<Office>> GetOfficesAsync()
        {
            var sql = "SELECT * FROM Offices;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Office>(sql);
                return result.ToList();
            }
        }

        public async Task<bool> UpdateOfficeAsync(Office officeToUpdate)
        {
            var sql = "UPDATE Offices SET Name = @Name WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, officeToUpdate);
                return affectedRows == 1;
            }
        }
    }
}