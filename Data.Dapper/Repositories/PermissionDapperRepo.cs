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
    public class PermissionDapperRepo : IPermissionRepo
    {
        private readonly SqlServerConnectionProvider _provider;

        public PermissionDapperRepo(SqlServerConnectionProvider provider)
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

        public async Task<bool> CreatePermissionAsync(Permission permission)
        {
            var sql = "INSERT INTO Permissions (Id, Name, Description) VALUES (@Id, @Name, @Description);";
            using (var connection = Context)
            {
                permission.Id = Guid.NewGuid();
                var affectedRows = await connection.ExecuteAsync(sql, permission);
                return affectedRows == 1;
            }
        }

        public async Task<bool> DeletePermissionAsync(Guid permissionId)
        {
            var sql = "DELETE FROM Permissions WHERE Id = @Id";
            using (var connection = Context)
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = permissionId });
                return affectedRows == 1;
            }
        }

        public async Task<Permission> GetPermissionByIdAsync(Guid permissionId)
        {
            var sql = "SELECT * FROM Permissions WHERE Id = @Id";
            using (var connection = Context)
            {
                var perm = await connection.QueryFirstAsync<Permission>(sql, new { Id = permissionId });
                return perm;
            }
        }

        public async Task<List<Permission>> GetPermissionsAsync()
        {
            var sql = "SELECT * FROM Permissions;";
            using (var connection = Context)
            {
                var result = await connection.QueryAsync<Permission>(sql);
                return result.ToList();
            }
        }

        public async Task<bool> UpdatePermissionAsync(Permission permissionToUpdate)
        {
            var sql = "UPDATE Permissions SET Name = @Name, Description = @Description WHERE Id = @Id;";
            using (var connection = Context)
            {
                var affectedRows = await connection.ExecuteAsync(sql, permissionToUpdate);
                return affectedRows == 1;
            }
        }
    }
}
