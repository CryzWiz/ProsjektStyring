using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Data
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string Team_UniqueId { get; set; }
        public string TeamLeader { get; set; }
        public DateTime Registered { get; set; }
        public bool Active { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }

    }
}
