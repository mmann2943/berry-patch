using System;
using System.Collections.Generic;

namespace BerryPatch.Activity
{
    public class Activities: List<Activity>
    {
        public virtual bool Save()
        {
            throw new NotImplementedException();
        }
    }
}