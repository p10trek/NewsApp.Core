using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core.ResponseModel
{
    public class FireBaseResponse
    {
        public string User { get; set; }
        public List<string> Favorites { get; set; }
        public List<string> History { get; set; }
        public Preferences UserPreferences { get; set; }

    }
    public class Preferences
    {
        public string Categories { get; set; }
        public string Search { get; set; }
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
