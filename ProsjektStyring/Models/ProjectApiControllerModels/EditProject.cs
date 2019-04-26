using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectApiControllerModels
{
    public class EditProject
    {
        public string Unique_ProjectIdString { get; set; }
        public bool ProjectActive { get; set; }
        public bool ProjectCompleted { get; set; }
        public string ProjectName { get; set; }
        public string ProjectClient { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime ProjectPlannedStart { get; set; }
        public DateTime ProjectPlannedEnd { get; set; }
        public string user { get; set; }
    }
}
