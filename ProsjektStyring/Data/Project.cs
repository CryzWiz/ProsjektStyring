using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Data
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Unique_ProjectIdString { get; set; }

        public string ProjectName { get; set; }
        public string ProjectClient { get; set; }
        public string ProjectDescription { get; set; }

        public int NumberOfProjectCycles { get; set; }

        public bool ProjectActive { get; set; }
        public bool ProjectCompleted { get; set; }

        public DateTime ProjectPlannedStart { get; set; }
        public DateTime ProjectStart { get; set; }
        public DateTime ProjectPlannedEnd { get; set; }
        public DateTime ProjectEnd { get; set; }
        public DateTime ProjectRegistered { get; set; }

        public string ProjectCreatedByUser { get; set; }
        public string ProjectClosedByUser { get; set; }

        public List<ProjectCycle> ProjectCycles { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }

    }
}
