using System;
using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class Project : Entity<ProjectId>
    {
        protected Project()
        {
            Designation = Designation.None;
        }

        public Project(Designation designation, DateTimeOffset beginOfProject,
            DateTimeOffset endOfProject) : this()
        {
            Designation = designation;
            BeginOfProject = beginOfProject;
            EndOfProject = endOfProject;
        }

        public Designation Designation { get; }
        public DateTimeOffset BeginOfProject { get; }
        public DateTimeOffset EndOfProject { get; }
    }
}
