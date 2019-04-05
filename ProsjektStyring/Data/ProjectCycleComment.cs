using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Data
{
    public class ProjectCycleComment
    {
        [Key]
        public int ProjectCycleCommentId { get; set; }

        [ForeignKey("ProjectCycleId")]
        public int ProjectCycleId { get; set; }

        public DateTime CommentRegistered { get; set; }
        public string ByUser { get; set; }
        public string Comment { get; set; }
    }
}
