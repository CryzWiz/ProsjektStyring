using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Data
{
    public class ProjectTask
    {
        [Key]
        public int ProjectTaskId { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }


        public int ProjectCycle { get; set; }
        public string Unique_TaskIdString { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskStatus { get; set; }

        public string TaskUnderUser { get; set; }
        public bool LockedUnderUser { get; set; }

        public bool Active { get; set; }

        public double PlannedHours { get; set; }
        public double TotalHoursSpent { get; set; }
        public int ProsentageDone { get; set; }

        public DateTime TaskRegistered { get; set; }
        public DateTime TaskDueDate { get; set; }

        public DateTime TaskCleared { get; set; }
        public string TaskClearedByUser { get; set; }

    }
}
