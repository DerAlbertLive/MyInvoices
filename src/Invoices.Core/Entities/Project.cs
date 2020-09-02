using System;

namespace Invoices.Core.Entities
{
    public class Project : Entity
    {
        public Project()
        {
            Description = string.Empty;
        }
        public string Description { get; set; }
        public DateTimeOffset BeginOfProject { get; set; }
        public DateTimeOffset EndOfProject { get; set; }
    }
}
