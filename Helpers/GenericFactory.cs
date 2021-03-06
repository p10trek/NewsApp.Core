using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core.Helpers
{
    public static class GenericFactory<T> where T : class, new()
    {
        public static T CreateInstance()
        {
            T instance;
            instance = new T();
            return instance;
        }
        public static T CreateInstance(string arg)
        {
            T instance;
            instance = (T)Activator.CreateInstance(typeof(T), arg);
            return instance;
        }
    }
}
