using System.Data;
using System.Data.Entity;

namespace Eferada.Data.DatabaseContext
{
    public static class DbContextExtensions
    {
        public static DbContextTransaction BeginTransaction(this DbContext context,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return context.Database.BeginTransaction(isolationLevel);
        }
    }
}