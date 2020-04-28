using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PostModels
{
    public class PostUpdateModel
    {
        public int PostId { get; set; }
        public string UpdatedTitle  { get; set; }
        public string UpdatedText { get; set; }

    }
}
