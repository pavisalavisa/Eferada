using Eferada.Data.Model.Entities.Base;
using System;

namespace Eferada.Data.Model.Entities
{
    public class Notice : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDateTime { get; set; }
        public int NoticeCreatorId { get; set; }

        public Employee NoticeCreator { get; set; }
    }
}