using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Safrani.Model
{
    public class Thing
    {
        public Guid Guid { get; set; }
        public virtual int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public IIdentity CreatedBy { get; set; } 
        public IIdentity ModifiedBy { get; set; }
    }
}
