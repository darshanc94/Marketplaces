using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DataAccessLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        public string ConnectionStringName { get; set; } = "MarketplaceDB";
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            try
            {
                string connectionString = _config.GetConnectionString(ConnectionStringName);

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var data = await connection.QueryAsync<T>(sql, parameters);

                    return data.ToList();
                }
            }
            catch (SqlException e)
            {

                throw e;
            }



        }

        public async Task<T> LoadDataSingular<T, U>(string sql, U parameters)
        {
            try
            {
                string connectionString = _config.GetConnectionString(ConnectionStringName);

                using (IDbConnection connection = new SqlConnection(connectionString))
                {

                    var data = await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);

                    return data;
                }
            }
            catch (SqlException e)
            {

                throw e;
            }



        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            try
            {
                string connectionString = _config.GetConnectionString(ConnectionStringName);

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    await connection.ExecuteAsync(sql, parameters);
                }

            }
            catch (SqlException e)
            {
               
                throw e;
            }



        }

        public async Task<int> SaveDataID<T>(string sql, T parameters)
        {
            try
            {
                string connectionString = _config.GetConnectionString(ConnectionStringName);

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var data = await connection.ExecuteScalarAsync<int>(sql, parameters);

                    return data;
                }
            }
            catch (SqlException e)
            {
                Trace.WriteLine(e.Message);
                throw e;
            }



        }
    }
}