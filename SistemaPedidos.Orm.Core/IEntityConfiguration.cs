using Microsoft.EntityFrameworkCore;

namespace SistemaPedidos.Orm.Core
{
    public interface IEntityConfiguration
    {
        void Configure(ModelBuilder builder);
    }
}
