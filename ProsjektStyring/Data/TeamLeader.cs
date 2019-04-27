using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Data
{
    public class TeamLeader
    {
        public string Team_UniqueId { get; set; }
        public Team Team { get; set; }

        public string UserName { get; set; }
        public ApplicationUser User { get; set; }
    }
}
