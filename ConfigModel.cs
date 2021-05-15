using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core
{
    class ConfigModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public RequestModel FilterSettings { get; set; }
    }
}
