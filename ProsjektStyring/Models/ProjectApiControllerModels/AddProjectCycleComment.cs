using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectApiControllerModels
{
    public class AddProjectCycleComment
    {
        public string projectCycleId { get; set; }
        public string user { get; set; }
        public string commentHeading { get; set; }
        public string comment { get; set; }
    }
}
