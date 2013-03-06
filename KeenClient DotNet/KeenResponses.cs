using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeenClient_DotNet
{
    class KeenResponses
    {
    }
    public class VersionsResponse
    {
        public bool is_public { get; set; }
        public string url { get; set; }
        public string version { get; set; }
        public string error_code { get; set; }
        public string message { get; set; }
    }

}
