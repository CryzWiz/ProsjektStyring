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

        public string CycleName { get; set; }
        public string CycleDescription { get; set; }
        public int CycleNumber { get; set; }

        public bool CycleActive { get; set; }
        public bool CycleFinished { get; set; }

        public DateTime CycleRegistered { get; set; }
        public DateTime CyclePlannedStart { get; set; }
        public DateTime CycleStart { get; set; }
        public DateTime CyclePlannedEnd { get; set; }
        public DateTime CycleEnd { get; set; }

        public List<ProjectCycleTask> ProjectCycleTasks { get; set; }
        public List<ProjectCycleComment> ProjectCycleComments { get; set; }
    }
}
