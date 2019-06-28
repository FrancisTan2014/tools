using Francis.ToolBox.Api.Entities;
using Francis.ToolBox.Api.Repositories;
using System.Collections.Generic;

namespace Francis.ToolBox.Api.Services
{
    public class ConnectionService
    {
        private readonly IConnectionRepository _connectionRepository;

        public ConnectionService(IConnectionRepository connectionRepository)
        {
            _connectionRepository = connectionRepository;
        }

        public int Insert(Connection connection)
        {
            return _connectionRepository.Insert(connection);
        }

        public bool Update(Connection connection)
        {
            return _connectionRepository.Update(connection);
        }

        public bool Delete(int id)
        {
            return _connectionRepository.Delete(id);
        }

        public List<Connection> QueryAll()
        {
            return _connectionRepository.QueryAll() ?? new List<Connection>();
        }

        public Connection QuerySingle(int id)
        {
            return _connectionRepository.QuerySingle(id);
        }
    }
}
