using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Common
{
    public class BaseModel<TKey> : IDeletableEntity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
        public bool isDelete { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
