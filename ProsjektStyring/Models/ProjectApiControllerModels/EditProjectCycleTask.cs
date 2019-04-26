using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectApiControllerModels
{
    public class EditProjectCycleTask
    {
        public string unique_TaskIdString { get; set; }
        public string user { get; set; }
        public string cycleTaskName { get; set; }
        public string cycleTaskDescription { get; set; }
        public double plannedHours { get; set; }
        public DateTime dueDate { get; set; }
        public bool taskActive { get; set; }
    }
}
