using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Data
{
    public class ProjectComment
    {
        [Key]
        public int ProjectCommentId { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }        

        public DateTime CommentRegistered { get; set; }
        public string ByUser { get; set; }
        public string CommentHeading { get; set; }
        public string Comment { get; set; }

        public string Unique_IdString { get; set; }
    }
}
