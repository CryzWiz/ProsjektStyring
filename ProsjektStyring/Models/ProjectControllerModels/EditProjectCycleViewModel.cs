using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectControllerModels
{
    public class EditProjectCycleViewModel
    {
        [Required]
        public string unique_CycleIdString { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Navn")]
        public string cycleName { get; set; }

        [Display(Name = "Beskrivelse")]
        [DataType(DataType.MultilineText)]
        public string cycleDescription { get; set; }

        [Display(Name = "Planlagt start")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime startDate { get; set; }

        [Display(Name = "Planlagt slutt")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime endDate { get; set; }

        [Display(Name = "Aktiv")]
        public bool cycleActive { get; set; }
        [Display(Name = "Fullført")]
        public bool cycleFinished { get; set; }
    }
}
