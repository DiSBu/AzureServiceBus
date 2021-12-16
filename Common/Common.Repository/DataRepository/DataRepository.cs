using Common.Logger;
using Common.Model.Entities;
using Common.Model.Settings;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Common.Repository.DataRepository
{
    public class DataRepository : IDataRepository
    {       
        protected IDataConnection _connectionManager;
        private readonly SqlConnectionsSetting _sqlConnectionsSetting;
        private ILoggingService _logger;

        public DataRepository(IDataConnection connectionManager, IOptionsMonitor<SqlConnectionsSetting> sqlConnectionsSetting, ILoggingService logger)
        {            
            _connectionManager = connectionManager;
            _sqlConnectionsSetting = sqlConnectionsSetting?.CurrentValue;
            _logger = logger;
            _logger?.LogInformation($"{ this.GetType().Name}: is created.");
        }

        public IEnumerable<Data> GetData()
        {
            try
            {
                using (var conn = this._connectionManager.CreateConnection(_sqlConnectionsSetting.Website.ConnectionString))
                {
                    conn.Open();
                    _logger.LogDebug($"{ this.GetType().Name}: GetData started");

                    List<Data> results =
                        conn.Query<Data>(
                            "SPName",
                            commandType: CommandType.StoredProcedure).ToList();

                    _logger.LogDebug($"{ this.GetType().Name}: GetData finished with count ({results?.Count ?? 0})");

                    return results;
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"{ this.GetType().Name}: Exception in GetData");

                throw;
            }
        }
    }
}