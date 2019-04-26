using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Data
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Unique_ProjectIdString { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Navn")]
        public string ProjectName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Klient")]
        public string ProjectClient { get; set; }

        [Display(Name = "Beskrivelse")]
        [DataType(DataType.MultilineText)]
        public string ProjectDescription { get; set; }

        [Display(Name = "Antall sykluser")]
        public int NumberOfProjectCycles { get; set; }
        [Display(Name = "Aktiv")]
        public bool ProjectActive { get; set; }
        [Display(Name = "Fullført")]
        public bool ProjectCompleted { get; set; }

        [Display(Name = "Planlagt start")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ProjectPlannedStart { get; set; }

        [Display(Name = "Start")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ProjectStart { get; set; }

        [Display(Name = "Planlagt slutt")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ProjectPlannedEnd { get; set; }

        [Display(Name = "Fullført")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ProjectEnd { get; set; }

        [Display(Name = "Registrert")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ProjectRegistered { get; set; }

        [Display(Name = "Opprettet av")]
        public string ProjectCreatedByUser { get; set; }

        [Display(Name = "Lukket av")]
        public string ProjectClosedByUser { get; set; }

        public List<ProjectCycle> ProjectCycles { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }

    }
}
