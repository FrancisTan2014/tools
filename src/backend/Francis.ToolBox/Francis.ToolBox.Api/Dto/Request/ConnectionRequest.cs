using Francis.ToolBox.Entities;
using System.ComponentModel.DataAnnotations;

namespace Francis.ToolBox.Api.Dto.Request
{
    public class ConnectionRequest
    {
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public DatabaseType DbType { get; set; }
        [Required, MaxLength(15)]
        public string Host { get; set; }
        [Required, MaxLength(4)]
        public string Port { get; set; }
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
    }
}
