using ProsjektStyring.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectControllerModels
{
    public class ViewProjectViewModel
    {
        [Display(Name = "Prosjekt")]
        public Project Project { get; set; }
    }
}
