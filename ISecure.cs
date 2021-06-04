using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace NewsApp.Core
{
    public interface ISecure
    {
        SecureString Password { get; set; }
    }
}
