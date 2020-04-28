using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CommentModels
{
    public class CommentUpdateModel
    {
        public int CommentId { get; set; }
        public string UpdatedText { get; set; }
        public int? UpdatedPostId { get; set; }
    }
}
