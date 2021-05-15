using NewsApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core
{
    public class RequestModel : IRequestModel
    {
        
        public string Token { get; set; }
        public string Categories { get; set; }
        public string Search { get; set;}
        public int Limit { get; set; }
        public string Url { get; set; }
        public int Timeout { get; set; } = -1;
        public DateTime published_after { get; set; }
        public DateTime published_before { get; set; }
        public DateTime published_on { get; set; }
        public string language { get; set; }
        public string domains { get; set; }
    }
}
