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
        
        public ProjectCycle ProjectCycle { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime todaysDate { get { return DateTime.Now.Date; } }

        [Required(ErrorMessage = "Syklus-id mangler")]
        [Display(Name = "Syklus-id")]
        public string tprojectCycleId { get; set; }

        [Required(ErrorMessage = "Brukernavn mangler")]
        [Display(Name = "Bruker")]
        public string user { get; set; }

        [Required(ErrorMessage = "Navn for oppgaven må fylles ut")]
        [Display(Name = "Oppgave")]
        public string taskName { get; set; }

        [Required(ErrorMessage = "Beskrivelse av oppgaven må fylles ut")]
        [Display(Name = "Beskrivelse")]
        public string taskDescription { get; set; }

        [Required(ErrorMessage = "Planlagt tid må fylles ut")]
        [Range(0.1, 1000.0,
        ErrorMessage = "Verdi for {0} må være mellom {1} og {2}.")]
        [Display(Name = "Planlagt tid")]
        public double tplannedHours { get; set; }

        [Required(ErrorMessage = "Frist for oppgaven må fylles ut")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Frist")]
        public DateTime tdueDate { get; set; }


    }
}
