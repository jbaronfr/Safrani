using System;
using System.Collections.Generic;
using System.Text;

namespace Safrani.Model.People
{
    public class Guest : Person
    {
        public override bool IsGuest => true;
    }
}
