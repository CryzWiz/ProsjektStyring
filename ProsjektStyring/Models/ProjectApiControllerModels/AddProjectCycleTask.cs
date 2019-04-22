using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectApiControllerModels
{
    public class AddProjectCycleTask
    {
        public string projectCycleId { get; set; }
        public string user { get; set; }
        public string cycleTTaskName { get; set; }
        public string cycleTaskDescription { get; set; }
        public double plannedHours { get; set; }
        public DateTime dueDate { get; set; }
    }
}
