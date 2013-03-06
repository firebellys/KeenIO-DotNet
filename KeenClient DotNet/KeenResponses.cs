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
        public string IsPublic { get; set; }
        public string Url { get; set; }
        public string Version { get; set; }
        public string ErrorMessage { get; set; }
    }

}
