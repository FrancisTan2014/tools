using Francis.ToolBox.Api.Entities;
using System.Collections.Generic;

namespace Francis.ToolBox.Api.Repositories
{
    public interface IConnectionRepository
    {
        int Insert(Connection connection);
        bool Update(Connection connection);
        bool Delete(int id);
        List<Connection> QueryAll();
    }
}
