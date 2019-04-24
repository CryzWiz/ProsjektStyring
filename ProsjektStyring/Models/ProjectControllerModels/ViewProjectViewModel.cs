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

        [Required(ErrorMessage = "Prosjekt-id mangler")]
        public string projectId { get; set; }
        [Required(ErrorMessage = "Brukernavn mangler")]
        [Display(Name = "Bruker")]
        public string user { get; set; }

        [Required(ErrorMessage = "Navn for syklusen må fylles inn")]
        [Display(Name = "Syklus navn")]
        [StringLength(60, MinimumLength = 3, 
            ErrorMessage = "Verdi for {0} må være mellom {1} og {2} tegn.")]
        public string cycleName { get; set; }

        [Required(ErrorMessage = "Beskrivelse for syklusen må fylles ut")]
        [Display(Name = "Syklus beskrivelse")]
        [StringLength(600, MinimumLength = 3,
            ErrorMessage = "Verdi for {0} må være mellom {1} og {2} tegn.")]
        public string cycleDescription { get; set; }

        [Required(ErrorMessage = "Startdato må fylles ut")]
        [DataType(DataType.Date)]
        [Display(Name = "Planlagt Startdato")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime startDate { get; set; }

        [Required(ErrorMessage = "Sluttdato må fylles ut")]
        [DataType(DataType.Date)]
        [Display(Name = "Planlagt Sluttdato")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime endDate { get; set; }
    }
}
