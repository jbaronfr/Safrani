using System;
using System.Collections.Generic;
using System.Text;

namespace Safrani.Model.People
{
    public class Host : Person
    {
        public override bool IsGuest => false;
    }
}
