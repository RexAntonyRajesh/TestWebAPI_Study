using System;

namespace Test.Domain.Base
{
    public class BaseEntity
    {
		public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TenantId { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
