using System;
using System.Collections.Generic;
using System.Text;

namespace IpekStore.Core.Domain.Abstractions
{
    public interface IBaseEntity
    {
        int Id { get; set; }
    }
}
