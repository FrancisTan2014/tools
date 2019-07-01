using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Francis.ToolBox.Abstractions;
using Francis.ToolBox.Api.Dto.Request;
using Francis.ToolBox.Factories;
using Francis.ToolBox.Services;
using Francis.ToolBox.SqlProviders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Francis.ToolBox.Api.Controllers
{
    public class CodeController : BaseController
    {
        private readonly ILogger _logger;
        private readonly ICodeGenerator _codeGenerator;

        public CodeController(ILogger<CodeController> logger, ICodeGenerator codeGenerator)
        {
            _logger = logger;
            _codeGenerator = codeGenerator;
        }

        public IActionResult GenerateEntityClass(
            [FromQuery]ColumnRequest request
            , [FromServices]SmartSqlBuilderFactory factory
            , [FromServices]ISqlProviderFactory sqlProviderFactory
            , [FromServices]ConnectionService connectionService
        )
        {
            var connection = connectionService.QuerySingle(request.ConnectionId);
            if (connection == null)
            {
                return null;
            }
            var dbService = DatabaseService.Create(factory, sqlProviderFactory, connection);
            var columns = dbService.ListColumns(request.TableName);
            var code = _codeGenerator.Execute(columns);
            return Success(code);
        }
    }
}
