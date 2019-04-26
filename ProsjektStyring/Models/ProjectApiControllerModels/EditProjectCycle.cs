using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectApiControllerModels
{
    public class EditProjectCycle
    {

        public string unique_CycleIdString { get; set; }
        public string cycleName { get; set; }
        public string cycleDescription { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool cycleActive { get; set; }
        public bool cycleFinished { get; set; }
        public string user { get; set; }
    }
}
