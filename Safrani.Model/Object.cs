using System;
using System.Collections.Generic;
using System.Text;

namespace Safrani.Model
{
    public class Object : Thing
    {
        public Thing OwnedBy { get; set; }
    }
}
