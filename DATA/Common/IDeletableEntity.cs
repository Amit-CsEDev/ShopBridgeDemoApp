using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Common
{
    public interface IDeletableEntity
    {
        public bool isDelete { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
