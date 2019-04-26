using ProsjektStyring.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectControllerModels
{
    public class ViewProjectCycleViewModel
    {

        [Required(ErrorMessage = "Syklus-id mangler")]
        [Display(Name = "Syklus-id")]
        public string projectCycleId { get; set; }

        [Required(ErrorMessage = "Navn for oppgaven må fylles ut")]
        [Display(Name = "Oppgave")]
        public string cycleTaskName { get; set; }

        [Required(ErrorMessage = "Beskrivelse av oppgaven må fylles ut")]
        [Display(Name = "Beskrivelse")]
        public string cycleTaskDescription { get; set; }

        [Required(ErrorMessage = "Planlagt tid må fylles ut")]
        [Range(0.1, 1000.0,
        ErrorMessage = "Verdi for {0} må være mellom {1} og {2}.")]
        [Display(Name = "Planlagt tid")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Må være et siffer (eks: 1.2)")]
        public double plannedHours { get; set; }

        [Required(ErrorMessage = "Frist for oppgaven må fylles ut")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Frist")]
        public DateTime dueDate { get; set; }

        public ProjectCycle ProjectCycle { get; set; }


    }
}
