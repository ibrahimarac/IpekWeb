using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.Models.Globals
{
    public enum Status
    {
        Ok,
        BadRequest,
        NotFound,
        Error
    }
    public class JResult
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
