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
        public async Task<IActionResult> AddProjectCycle([FromBody] AddProjectCycle projectCycle)
        {
            if (ModelState.IsValid)
            {
                var result = await _projectRepository.AddCycleToProjectAsync(projectCycle);

                if (result != null)
                {
                    ProjectCycle c = new ProjectCycle
                    {
                        CycleActive = result.CycleActive,
                        CycleName = result.CycleName,
                        CycleDescription = result.CycleDescription,
                        CyclePlannedStart = result.CyclePlannedStart,
                        CyclePlannedEnd = result.CyclePlannedEnd,
                        Unique_CycleIdString = result.Unique_CycleIdString,
                        CycleNumber = result.CycleNumber
                    };
                    return Ok(c);
                }
                else return Ok("error");
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpGet("AddProjectComment")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole + " , " + RoleOptions.MemberRole)]
        public IActionResult AddProjectComment()
        {
            return Ok("Teststring");
        }
    }
}