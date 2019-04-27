using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Data
{
    public class TeamToProject
    {

        [ForeignKey("TeamId")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
