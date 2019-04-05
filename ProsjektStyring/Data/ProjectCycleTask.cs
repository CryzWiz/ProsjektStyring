using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Data
{
    public class ProjectCycleTask
    {
        [Key]
        public int ProjectCycleTaskId { get; set; }
        public string Unique_TaskIdString { get; set; }

        [ForeignKey("ProjectCycleId")]
        public int ProjectCycleId { get; set; }
        public ProjectCycle ProjectCycle { get; set; }

        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskStatus { get; set; }

        public string TaskUnderUser { get; set; }
        public bool LockedUnderUser { get; set; }

        public bool TaskActive { get; set; }
        public bool TaskCompleted { get; set; }

        public double PlannedHours { get; set; }
        public double TotalHoursSpent { get; set; }
        public int ProsentageDone { get; set; }

        public DateTime TaskRegistered { get; set; }
        public DateTime TaskDueDate { get; set; }

        public DateTime TaskCleared { get; set; }
        public string TaskClearedByUser { get; set; }

        public List<ProjectTaskComment> ProjectTaskComments { get; set; }

    }
}
