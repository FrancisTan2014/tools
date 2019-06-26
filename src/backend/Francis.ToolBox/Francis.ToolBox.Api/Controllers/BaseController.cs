using Francis.ToolBox.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Francis.ToolBox.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController: Controller
    {
        public BaseController()
        {
            
        }

        protected JsonResult Success(object data = null)
        {
            var response = ApiResponse.OfSuccess(ErrorInfo.OfRequestSuccess(), data);
            return Json(response);
        }

        protected JsonResult Failed(string message = null)
        {
            var response = ApiResponse.OfFailed(ErrorInfo.OfRequestFailed(message));
            return Json(response);
        }

        protected JsonResult Failed(ErrorInfo errorInfo, object data = null)
        {
            var response = ApiResponse.OfFailed(errorInfo, data);
            return Json(response);
        }
    }
}
