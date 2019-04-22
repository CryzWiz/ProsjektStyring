using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectApiControllerModels
{
    public class AddProjectCycleTask
    {
        public string projectCycleId { get; set; }
        public string user { get; set; }
        public string cycleTaskName { get; set; }
        public string cycleTaskDescription { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double plannedHours { get; set; }
        public DateTime dueDate { get; set; }
    }
}
