using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core.Interfaces
{
    public interface IRequestModel
    {
        
         string Token { get; set; }
         string Categories { get; set; }
         string Search { get; set;}
         DateTime published_after { get; set; }
         DateTime published_before { get; set; }
         DateTime published_on { get; set; }
         string language { get; set; }
         string domains { get; set; }
         int Limit { get; set; }
         string Url { get; set; }
         int Timeout { get; set; }
    }
}
