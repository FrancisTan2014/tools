using Francis.ToolBox.Api.Dto.Request;
using Francis.ToolBox.Api.Entities;
using Francis.ToolBox.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Util.Maps;

namespace Francis.ToolBox.Api.Controllers
{
    public class ConnectionsController : BaseController
    {
        private readonly ConnectionService _connectionService;

        public ConnectionsController(ConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = _connectionService.QueryAll();
            return Success(data);
        }

        [HttpPost]
        public JsonResult Post([FromBody]ConnectionRequest request)
        {
            var data = request.MapTo<Connection>();
            var id = _connectionService.Insert(data);
            return id > 0 ? Success(id) : Failed();
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]ConnectionRequest request)
        {
            request.Id = id;
            var data = request.MapTo<Connection>();
            var success = _connectionService.Update(data);
            return success ? Success() : Failed();
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var success = _connectionService.Delete(id);
            return success ? Success() : Failed();
        }
    }
}