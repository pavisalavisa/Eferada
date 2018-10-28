using System;

namespace Eferada.Data.Model.Contracts
{
    public interface ILastUpdatedTimestampAuditable
    {
        DateTime LastUpdatedTimestamp { get; set; }
    }
}
