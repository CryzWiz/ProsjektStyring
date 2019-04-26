using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectApiControllerModels
{
    public class AddProject
    {
        public string ProjectName { get; set; }
        public string ProjectClient { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime ProjectPlannedStart { get; set; }
        public DateTime ProjectPlannedEnd { get; set; }
        public string ProjectCreatedByUser { get; set; }
    }
}
