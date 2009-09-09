using System;
using System.Collections.Generic;

namespace BerryPatch.Repository.Activity
{
    public class Activities: List<BerryPatch.Activity.Activity>
    {
        public virtual bool Save()
        {
            throw new NotImplementedException();
        }
    }
}