using System;

namespace Invoices.Core.Entities
{
    public interface IEntityChanged
    {
        void Created();
        void Changed();
    }
}
