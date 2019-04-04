using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Data
{
    public class ProjectTaskComment
    {
        [Key]
        public int ProjectTaskCommentId { get; set; }
        public int ProjectTaskId { get; set; }
        [ForeignKey("ProjectTaskId")]
        public ProjectTask ProjectTask { get; set; }

        public DateTime CommentRegistered { get; set; }
        public string ByUser { get; set; }
        public string Comment { get; set; }

    }
}
