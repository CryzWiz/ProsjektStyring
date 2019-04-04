using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectControllerModels
{
    public class CreateProjectViewModel
    {
        public string ProjectName { get; set; }
        public string ProjectClient { get; set; }
        public string ProjectDescription { get; set; }

        public DateTime ProjectPlannedStart { get; set; }
        public DateTime ProjectPlannedEnd { get; set; }
    }
}
