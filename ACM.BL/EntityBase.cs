using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public enum EntityStateOption
    {
        Active,
        Deleted
    }

    public abstract class EntityBase
    {
        public EntityStateOption EntityState { get; set; }
        public bool HasChanges { get; private set; }
        public bool IsNew { get; private set; }
        public bool IsValid
        {
            get
            {
                return Validate(); //for now
            }
        }

        protected abstract bool Validate();
       
    }
}
