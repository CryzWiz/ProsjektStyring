using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectControllerModels
{
    public class EditProjectCycleTaskViewModel
    {
        [Required(ErrorMessage = "Oppgave-id mangler")]
        public string unique_TaskIdString { get; set; }

        [Required(ErrorMessage = "Navn for oppgaven må oppgis")]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Navn")]
        public string cycleTaskName { get; set; }

        [Display(Name = "Beskrivelse")]
        [DataType(DataType.MultilineText)]
        public string cycleTaskDescription { get; set; }

        [Required(ErrorMessage = "Beregnet tid for oppgaven må oppgis")]
        [Range(0.1, 1000.0,
        ErrorMessage = "Verdi for {0} må være mellom {1} og {2}.")]
        [Display(Name = "Planlagt tid")]
        public double plannedHours { get; set; }

        [Required(ErrorMessage = "Frist for oppgaven må oppgis")]
        [Display(Name = "Frist")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dueDate { get; set; }

        [Display(Name = "Aktiv")]
        public bool taskActive { get; set; }
    }
}
