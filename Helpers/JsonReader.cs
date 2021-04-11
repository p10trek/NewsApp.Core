using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core
{
    public static class JsonReader<T>
    {
        public static T JsonDeserialize(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
