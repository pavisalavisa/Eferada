﻿using Eferada.Data.Model.Entities.Base;
using System;

namespace Eferada.Data.Model.Entities
{
    public class SubjectTest : BaseEntity
    {
        public DateTime DateTime { get; set; }
        public int CourseId { get; set; } //TODO: 1 to many
        public int SubjectId { get; set; } //TODO: 1 to many
        public int Term { get; set; }

        public virtual Course Course { get; set; }
        public virtual Subject Subject { get; set; }
    }
}