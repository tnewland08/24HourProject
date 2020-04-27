using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        [ForeignKey("LikedPost")]
        public int PostId { get; set; }
        public virtual Post LikedPost { get; set; }
        [ForeignKey("Liker")]
        public Guid UserId { get; set; }
        public virtual User Liker { get; set; }
    }
}
