using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsModels
{
    [Serializable()]
    public class NewsCategory
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name = String.Empty;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public NewsCategory() { }
    }
}
