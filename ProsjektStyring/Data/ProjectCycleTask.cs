using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Data
{
    public class ProjectCycleTask
    {
        [Key]
        public int ProjectCycleTaskId { get; set; }
        public string Unique_TaskIdString { get; set; }

        [ForeignKey("ProjectCycleId")]
        public int ProjectCycleId { get; set; }
        public ProjectCycle ProjectCycle { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Oppgave")]
        public string TaskName { get; set; }

        [Display(Name = "Beskrivelse")]
        [DataType(DataType.MultilineText)]
        public string TaskDescription { get; set; }

        [Display(Name = "Status")]
        public string TaskStatus { get; set; }


        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Låst til")]
        public string TaskUnderUser { get; set; }

        [Display(Name = "Låst til bruker")]
        public bool LockedUnderUser { get; set; }

        [Display(Name = "Oppgave aktiv")]
        public bool TaskActive { get; set; }

        [Display(Name = "Oppgave fullført")]
        public bool TaskCompleted { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Duration)]
        [Column(TypeName = "double(18, 2)")]
        [Display(Name = "Planlagt tid")]
        public double PlannedHours { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Duration)]
        [Column(TypeName = "double(18, 2)")]
        [Display(Name = "Tid brukt")]
        public double TotalHoursSpent { get; set; }

        [Display(Name = "Fremgang")]
        public int ProsentageDone { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Oppgave registrert")]
        public DateTime TaskRegistered { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Frist")]
        public DateTime TaskDueDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Oppgave klarert")]
        public DateTime TaskCleared { get; set; }

        [Display(Name = "Klarert av")]
        public string TaskClearedByUser { get; set; }

        public List<ProjectTaskComment> ProjectTaskComments { get; set; }

    }
}
