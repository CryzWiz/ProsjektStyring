using ProsjektStyring.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectControllerModels
{
    public class IndexViewModel
    {
        [Display(Name = "Uaktiverte prosjekter")]
        public List<Project> UnActivatedProjects { get; set; }
        [Display(Name = "Aktive prosjekter")]
        public List<Project> ActiveProjects { get; set; }
        [Display(Name = "Ferdigstilte prosjekter")]
        public List<Project> CompletedProjects { get; set; }

    }
}
