using NewsApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core
{
    public class AllNewsModel : ObservableBase
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { Set(ref age, value); }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }
        private string _content;
        public string Content
        {
            get { return _content; }
            set { Set(ref _content, value); }
        }
        private string _image;
        public string Image
        {
            get { return _image; }
            set { Set(ref _image, value); }
        }

    }
}

