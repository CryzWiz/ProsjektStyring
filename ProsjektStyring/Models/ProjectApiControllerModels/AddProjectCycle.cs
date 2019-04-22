using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectApiControllerModels
{
    public class AddProjectCycle
    {
        public string projectId { get; set; }
        public string user { get; set; }
        public string cycleName { get; set; }
        public string cycleDescription { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
