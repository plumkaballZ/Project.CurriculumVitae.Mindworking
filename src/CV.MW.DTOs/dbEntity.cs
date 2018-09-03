using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.DTOs
{
    public abstract class dbEntity
    {
        public Guid Uid { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeltedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
