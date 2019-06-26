using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Francis.ToolBox.Api.Dto.Request
{
    public class ConnectionRequest
    {
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
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
