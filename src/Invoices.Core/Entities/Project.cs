using System;
using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class Project : Entity
    {
        protected Project()
        {
            Description = ShortDescription.Empty();
        }

        public Project(ShortDescription description, DateTimeOffset beginOfProject,
            DateTimeOffset endOfProject) : this()
        {
            Description = description;
            BeginOfProject = beginOfProject;
            EndOfProject = endOfProject;
        }

        public ShortDescription Description { get; }
        public DateTimeOffset BeginOfProject { get; }
        public DateTimeOffset EndOfProject { get; }
    }
}
