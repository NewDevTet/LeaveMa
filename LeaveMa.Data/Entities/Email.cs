using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Entities
{
    public class Email : BaseEntity
    {
        public string Code { get; set; }
        public string Value { get; set; }
    }
}
