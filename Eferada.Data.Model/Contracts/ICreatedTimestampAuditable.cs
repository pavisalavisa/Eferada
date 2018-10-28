using System;

namespace Eferada.Data.Model.Contracts
{
    public interface ICreatedTimestampAuditable
    {
        DateTime CreatedTimestamp { get; set; }
    }
}
