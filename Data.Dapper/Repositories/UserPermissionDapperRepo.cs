using Dapper;
using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using System.Data;
using System.Threading.Tasks;

namespace Data.Dapper.Repositories
{
    public class UserPermissionDapperRepo : IUserPermissionRepo
    {
        private readonly SqlServerConnectionProvider _provider;

        public UserPermissionDapperRepo(SqlServerConnectionProvider provider)
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
        public async Task<bool> AsignUserPermissionAsync(UserPermission userPermission)
        {
            var sql = "INSERT INTO UserPermissions (UserId, PermissionId) VALUES (@UserId, @PermissionId);";
            using (var connection = Context)
            {
                var affectedRows = await connection.ExecuteAsync(sql, userPermission);
                return affectedRows == 1;
            }
        }
    }
}
