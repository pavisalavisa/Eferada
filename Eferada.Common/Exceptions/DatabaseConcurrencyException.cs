using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace Eferada.Common.Exceptions
{
    public class DatabaseConcurrencyException : DbUpdateException
    {
        public new IEnumerable<DbEntityEntry> Entries { get; set; }

        public DatabaseConcurrencyException(IEnumerable<DbEntityEntry> entries)
        {
            Entries = entries;
        }

        public DatabaseConcurrencyException(string message, IEnumerable<DbEntityEntry> entries) : base (message)
        {
            Entries = entries;
        }

        public DatabaseConcurrencyException(string message,IEnumerable<DbEntityEntry> entries,Exception innerException) : base (message,innerException)
        {
            Entries = entries;
        }
    }
}