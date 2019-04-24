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

        [Required]
        [Display(Name = "Syklus-id")]
        public string tprojectCycleId { get; set; }

        [Required]
        [Display(Name = "Bruker")]
        public string user { get; set; }
        [Required]
        [Display(Name = "Oppgave")]
        public string taskName { get; set; }
        [Required]
        [Display(Name = "Beskrivelse")]
        public string taskDescription { get; set; }
        [Required]
        [DataType(DataType.Duration)]
        [Display(Name = "Planlagt tid")]
        public double tplannedHours { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Frist")]
        public DateTime tdueDate { get; set; }


    }
}
