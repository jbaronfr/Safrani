using System;
using System.Collections.Generic;
using System.Text;

namespace Safrani.Model
{
    public class Notion : Thing
    {
        public string Title { get; set; }
        public Type LinkedType { get; set; }
        public Notion ParentNotion { get; set; }
    }
}
