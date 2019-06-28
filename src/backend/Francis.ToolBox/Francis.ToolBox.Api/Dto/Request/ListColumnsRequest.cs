namespace Francis.ToolBox.Api.Dto.Request
{
    public class ListColumnsRequest : DatabaseRequest
    {
        public string TableName { get; set; }
    }
}
