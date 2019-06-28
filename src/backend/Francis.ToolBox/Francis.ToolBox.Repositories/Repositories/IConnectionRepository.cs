using Francis.ToolBox.Entities;
using System.Collections.Generic;

namespace Francis.ToolBox.Repositories
{
    public interface IConnectionRepository
    {
        int Insert(Connection connection);
        bool Update(Connection connection);
        bool Delete(int id);
        List<Connection> QueryAll();
        Connection QuerySingle(int id);
    }
}
