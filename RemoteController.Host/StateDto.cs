using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteController.Host
{
    public record StateDto
    {
        public string Id { get; set; }
        public string State { get; set; }
    }
}
