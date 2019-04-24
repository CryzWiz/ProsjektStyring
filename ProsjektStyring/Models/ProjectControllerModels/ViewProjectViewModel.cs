using ProsjektStyring.Data;
using ProsjektStyring.Models.ProjectApiControllerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.ProjectControllerModels
{
    public class ViewProjectViewModel
    {
        public Project Project { get; set; }

        [Required]
        public string projectId { get; set; }
        [Required]
        [Display(Name = "Bruker")]
        public string user { get; set; }

        [Required]
        [Display(Name = "Syklus navn")]
        [StringLength(60, MinimumLength = 3)]
        public string cycleName { get; set; }

        [Required]
        [Display(Name = "Syklus beskrivelse")]
        [StringLength(60, MinimumLength = 3)]
        public string cycleDescription { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Planlagt Startdato")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime startDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Planlagt Sluttdato")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime endDate { get; set; }
    }
}
