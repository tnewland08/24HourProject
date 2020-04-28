using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Reply : Comment
    {
        public virtual Comment ReplyComment { get; set; }
    }
}
