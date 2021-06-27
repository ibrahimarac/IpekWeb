using System;
using System.Collections.Generic;
using System.Text;

namespace IpekStore.Core.Domain.Abstractions
{
    public interface ITrackable
    {
        string CreateUser { get; set; }

        string LastupUser { get; set; }

        DateTime CreateDate { get; set; }

        DateTime LastupDate { get; set; }
    }
}
