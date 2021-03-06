﻿using System;

namespace Francis.ToolBox.Entities
{
    public class Connection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DatabaseType DbType { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
