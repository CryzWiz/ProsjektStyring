using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectControllerModels
{
    public class CreateProjectViewModel
    {
        [Required]
        [Display(Name = "Prosjektnavn")]
        public string ProjectName { get; set; }
        [Required]
        [Display(Name = "Oppdragsgiver")]
        public string ProjectClient { get; set; }
        [Required]
        [Display(Name = "Prosjektbeskrivelse")]
        public string ProjectDescription { get; set; }

        [Required]
        [Display(Name = "Planlagt Startdato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProjectPlannedStart { get; set; }
        [Required]
        [Display(Name = "Planlagt Sluttdato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProjectPlannedEnd { get; set; }
    }
}
