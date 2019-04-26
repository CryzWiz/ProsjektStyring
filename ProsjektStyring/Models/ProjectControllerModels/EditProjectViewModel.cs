using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectControllerModels
{
    public class EditProjectViewModel
    {
        [Required(ErrorMessage = "Prosjektid mangler...?")]
        public string Unique_ProjectIdString { get; set; }

        [Display(Name = "Aktiv")]
        public bool ProjectActive { get; set; }

        [Display(Name = "Fullført")]
        public bool ProjectCompleted { get; set; }

        [Required(ErrorMessage = "Navn for prosjektet må oppgis")]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Prosjektnavn")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Oppdragsgiver må oppgis")]
        [Display(Name = "Oppdragsgiver")]
        [StringLength(60, MinimumLength = 3)]
        public string ProjectClient { get; set; }

        [Required(ErrorMessage = "Prosjektbeskrivelse må oppgis")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Prosjektbeskrivelse")]
        public string ProjectDescription { get; set; }

        [Required(ErrorMessage = "Planlagt startdato for prosjektet må oppgis")]
        [Display(Name = "Planlagt Startdato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProjectPlannedStart { get; set; }

        [Required(ErrorMessage = "Planlagt sluttdato for prosjektet må oppgis")]
        [Display(Name = "Planlagt Sluttdato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProjectPlannedEnd { get; set; }
    }
}
