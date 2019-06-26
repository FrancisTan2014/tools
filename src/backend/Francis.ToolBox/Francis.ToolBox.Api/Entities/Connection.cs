using System;

namespace Francis.ToolBox.Api.Entities
{
    public class Connection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
