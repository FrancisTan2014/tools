using System;
using System.ComponentModel.DataAnnotations;

namespace Francis.ToolBox.Api.Dto.Request
{
    public class ColumnRequest
    {
        [Required]
        public int ConnectionId { get; set; }
        [Required]
        public string TableName { get; set; }
    }
}
