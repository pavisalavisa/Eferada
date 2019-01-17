using System;
using Eferada.Data.Model.Entities.Base;

namespace Eferada.Data.Model.Entities
{
    public class Notice : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDateTime { get; set; }

        public Employee NoticeCreator { get; set; }// TODO: add 1 to M configuration
    }
}