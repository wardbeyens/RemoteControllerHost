using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RemoteController.Host
{
    public record MessageDto
    {
        public string Id { get; set; }
        public XboxController Controller { get; set; }
    }
}
