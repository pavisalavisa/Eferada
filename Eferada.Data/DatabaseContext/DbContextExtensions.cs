using System.Data;
using System.Data.Entity;

namespace Eferada.DatabaseContext
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