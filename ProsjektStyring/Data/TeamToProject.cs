using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Data
{
    public class TeamToProject
    {
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
