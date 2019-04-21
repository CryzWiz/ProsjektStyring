using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProsjektStyring.Data;
using ProsjektStyring.Models.IRepositorys;
using ProsjektStyring.Models.ProjectApiControllerModels;
using ProsjektStyring.Models.SeedData;

namespace ProsjektStyring.Controllers
{
    [Produces("application/json")]
    [Route("api/Project")]
    public class ProjectAPIController : Controller
    {
        private IProjectRepository _projectRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectAPIController(IProjectRepository Pr, UserManager<ApplicationUser> uM)
        {
            _projectRepository = Pr;
            _userManager = uM;
        }

        [HttpGet("TestAPI")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole + " , " + RoleOptions.MemberRole)]
        public IActionResult TestApi()
        {
            return Ok("Teststring");
        }
        // [Bind("projectId", "user", "cycleName", "cycleDescription", "startDate", "endDate")] 
        [HttpPost("AddProjectCycle")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole)]
        public IActionResult AddProjectCycle([FromBody] AddProjectCycle projectCycle)
        {
            return Ok("data recived: "+ projectCycle.projectId + ","+ projectCycle.user+ ","
                + projectCycle.cycleName + ","+ projectCycle.cycleDescription + ","
                + projectCycle.startDate + ","+ projectCycle.endDate);
        }

        [HttpGet("AddProjectComment")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole + " , " + RoleOptions.MemberRole)]
        public IActionResult AddProjectComment()
        {
            return Ok("Teststring");
        }
    }
}