using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Data
{
    public class ProjectCycle
    {
        [Key]
        public int ProjectCycleId { get; set; }
        public string Unique_CycleIdString { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Navn")]
        public string CycleName { get; set; }

        [Display(Name = "Beskrivelse")]
        [DataType(DataType.MultilineText)]
        public string CycleDescription { get; set; }

        [Display(Name = "Syklus nr")]
        public int CycleNumber { get; set; }

        [Display(Name = "Aktiv")]
        public bool CycleActive { get; set; }
        [Display(Name = "Fullført")]
        public bool CycleFinished { get; set; }

        [Display(Name = "Registrert")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CycleRegistered { get; set; }

        [Display(Name = "Planlagt start")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CyclePlannedStart { get; set; }

        [Display(Name = "Startet")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CycleStart { get; set; }

        [Display(Name = "Planlagt slutt")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CyclePlannedEnd { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CycleEnd { get; set; }

        public List<ProjectCycleTask> ProjectCycleTasks { get; set; }
        public List<ProjectCycleComment> ProjectCycleComments { get; set; }
    }
}
