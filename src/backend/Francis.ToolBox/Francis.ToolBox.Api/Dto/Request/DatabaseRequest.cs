using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Francis.ToolBox.Api.Dto.Request
{
    public class DatabaseRequest
    {
        [Required, Range(1, int.MaxValue)]
        public int ConnectionId { get; set; }
    }
}
