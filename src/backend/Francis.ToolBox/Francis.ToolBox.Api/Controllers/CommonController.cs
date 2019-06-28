using Francis.ToolBox.Api.Dto.Response;
using Francis.ToolBox.Api.Entities;
using Francis.ToolBox.Api.Utils.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Francis.ToolBox.Api.Controllers
{
    public class CommonController : BaseController
    {
        public CommonController()
        {

        }

        private JsonResult ReturnKeyValueList(Dictionary<int, string> dict)
        {
            var list = dict.Select(pair => new KeyValue { Key = pair.Value, Value = pair.Key });
            return Success(list);
        }

        [HttpGet("types/database")]
        public JsonResult GetDatabaseTypes()
        {
            var dict = Enums.GetValueNameDict<DatabaseType>();
            return ReturnKeyValueList(dict);
        }
    }
}
