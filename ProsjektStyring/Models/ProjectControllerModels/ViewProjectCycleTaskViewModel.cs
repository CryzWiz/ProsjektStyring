using ProsjektStyring.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectControllerModels
{
    public class ViewProjectCycleTaskViewModel
    {
        public ProjectCycleTask ProjectCycleTask { get; set; }
        public ProjectCycle ProjectCycle { get; set; }
        public Project Project { get; set; }
    }
}
