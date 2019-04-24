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

        // ProjectCycle supporters
        [HttpPost("AddProjectCycle")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole)]
        public async Task<IActionResult> AddProjectCycle([FromBody]
        [Bind("projectId", "user", "cycleName", "cycleDescription", "startDate", "endDate")] AddProjectCycle projectCycle)
        {
            if (ModelState.IsValid)
            {
                ProjectCycle pC = await _projectRepository.AddCycleToProjectAsync(projectCycle);

                if (pC != null)
                {
                    ProjectCycle c = new ProjectCycle
                    {
                        CycleActive = pC.CycleActive,
                        CycleName = pC.CycleName,
                        CycleDescription = pC.CycleDescription,
                        CyclePlannedStart = pC.CyclePlannedStart,
                        CyclePlannedEnd = pC.CyclePlannedEnd,
                        Unique_CycleIdString = pC.Unique_CycleIdString,
                        CycleNumber = pC.CycleNumber
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


        // ProjectTask
        [HttpPost("AddProjectCycleTask")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole)]
        public async Task<IActionResult> AddProjectCycleTask([FromBody]
        [Bind("projectCycleId", "user", "cycleTaskName", "cycleTaskDescription", "plannedHours", "dueDate")] AddProjectCycleTask cT)
        {
            if (ModelState.IsValid)
            {
                ProjectCycleTask pT = await _projectRepository.AddTaskToCycleAsync(cT);

                if (pT != null)
                {
                    ProjectCycleTask c = new ProjectCycleTask
                    {
                        TaskActive = pT.TaskActive,
                        TaskDescription = pT.TaskDescription,
                        TaskName = pT.TaskName,
                        PlannedHours = pT.PlannedHours,
                        TaskCompleted = pT.TaskCompleted,
                        TotalHoursSpent = pT.TotalHoursSpent,
                        TaskRegistered = pT.TaskRegistered,
                        TaskDueDate = pT.TaskDueDate,
                        Unique_TaskIdString = pT.Unique_TaskIdString
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

        // Comments
        [HttpPost("AddProjectComment")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole + " , " + RoleOptions.MemberRole)]
        public async Task<IActionResult> AddProjectComment([FromBody]
        [Bind("projectId", "user", "CommentHeading", "comment")]AddProjectComment projectComment)
        {
            if (ModelState.IsValid)
            {
                ProjectComment pC = await _projectRepository.AddProjectCommentAsync(projectComment);
                if (pC != null)
                {
                    return Ok(pC);
                }
                else
                {
                    return Ok("error");
                }
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("AddProjectCycleComment")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole + " , " + RoleOptions.MemberRole)]
        public async Task<IActionResult> AddProjectCycleComment([FromBody]
        [Bind("projectCycleId", "user", "commentHeading", "comment")]AddProjectCycleComment projectCycleComment)
        {
            if (ModelState.IsValid)
            {
                ProjectCycleComment pC = await _projectRepository.AddProjectCycleCommentAsync(projectCycleComment);
                if (pC != null)
                {
                    return Ok(pC);
                }
                else
                {
                    return Ok("error");
                }
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("AddProjectCycleTaskComment")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole + " , " + RoleOptions.MemberRole)]
        public async Task<IActionResult> AddProjectCycleTaskComment([FromBody]
        [Bind("projectCycleTaskId", "user", "commentHeading", "comment")]AddProjectCycleTaskComment projectCycleTaskComment)
        {
            if (ModelState.IsValid)
            {
                ProjectCycleTaskComment pC = await _projectRepository.AddProjectCycleTaskCommentAsync(projectCycleTaskComment);
                if (pC != null)
                {
                    return Ok(pC);
                }
                else
                {
                    return Ok("error");
                }
            }
            else
            {
                return BadRequest();
            }

        }

    }
}