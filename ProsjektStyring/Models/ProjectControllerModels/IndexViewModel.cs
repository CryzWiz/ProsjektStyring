using ProsjektStyring.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectControllerModels
{
    public class IndexViewModel
    {

        public List<Project> ActiveProjects { get; set; }
        public List<Project> CompletedProjects { get; set; }

    }
}
