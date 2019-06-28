using Francis.ToolBox.Api.Dto.Request;
using Francis.ToolBox.Factories;
using Francis.ToolBox.Services;
using Francis.ToolBox.SqlProviders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Francis.ToolBox.Api.Controllers
{
    public class DatabaseController : BaseController
    {
        private readonly ConnectionService _connectionService;
        private readonly SmartSqlBuilderFactory _factory;
        private readonly ISqlProviderFactory _sqlProviderFactory;

        public DatabaseController(ConnectionService connectionService, SmartSqlBuilderFactory factory, ISqlProviderFactory sqlProviderFactory)
        {
            _connectionService = connectionService;
            _factory = factory;
            _sqlProviderFactory = sqlProviderFactory;
        }

        private DatabaseService GetDatabaseService(int connectionId)
        {
            var connection = _connectionService.QuerySingle(connectionId);
            if (connection == null)
            {
                return null;
            }
            return DatabaseService.Create(_factory, _sqlProviderFactory, connection);
        }

        private JsonResult GetListResult<T>(int connectionId, Func<DatabaseService, List<T>> getResult)
        {
            var dbService = GetDatabaseService(connectionId);
            if (dbService == null)
            {
                return Failed("Connection does not exist.");
            }
            var list = getResult(dbService);
            return Success(list);
        }


        [HttpGet]
        public JsonResult ListDatabases([FromQuery]DatabaseRequest request)
        {
            return GetListResult(request.ConnectionId, dbService => dbService.ListDatabases());
        }

        [HttpGet("tables")]
        public JsonResult ListTables([FromQuery]ListTablesRequest request)
        {
            return GetListResult(request.ConnectionId, dbService => dbService.ListTables(request.DbName));
        }

        public JsonResult ListColumns([FromQuery]ListColumnsRequest request)
        {
            return GetListResult(request.ConnectionId, dbService => dbService.ListColumns(request.TableName));
        }
    }
}
