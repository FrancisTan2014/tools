using System.ComponentModel.DataAnnotations;

namespace Francis.ToolBox.Api.Dto.Request
{
    public class ListTablesRequest : DatabaseRequest
    {
        [Required]
        public string DbName { get; set; }
    }
}
