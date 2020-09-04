using System;

namespace Invoices.Core.Entities
{
    public class ProjectId : EntityId<ProjectId>
    {
        public ProjectId(Guid id) : base(id)
        {
        }
    }
}