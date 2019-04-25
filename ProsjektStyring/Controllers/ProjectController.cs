﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProsjektStyring.Data;
using ProsjektStyring.Models.IRepositorys;
using ProsjektStyring.Models.ProjectApiControllerModels;
using ProsjektStyring.Models.ProjectControllerModels;
using ProsjektStyring.Models.SeedData;

namespace ProsjektStyring.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRepository _projectRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectController(IProjectRepository Pr, UserManager<ApplicationUser> uM)
        {
            _projectRepository = Pr;
            _userManager = uM;
        }

        ////////    Index     ////////
        [HttpGet]
        [Route("Project/")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole + " , " + RoleOptions.MemberRole)]
        public async Task<IActionResult> Index()
        {
            IndexViewModel model = new IndexViewModel
            {
                UnActivatedProjects = await _projectRepository.GetUnActivatedProjectsAsync(),
                ActiveProjects = await _projectRepository.GetActiveProjectsAsync(),
                CompletedProjects = await _projectRepository.GetCompletedProjectsAsync()
            };
            return View(model);
        }

        ////////    Project-functions     ////////
        [HttpGet]
        [Route("Project/{id}")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole + " , " + RoleOptions.MemberRole)]
        public async Task<IActionResult> ViewProject([FromRoute] string id)
        {            
            Project p = await _projectRepository.GetProjectByUniqueId(id);

            ViewProjectViewModel model = new ViewProjectViewModel
            {
                Project = p
            };
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole)]
        public IActionResult CreateProject()
        {
            CreateProjectViewModel model = new CreateProjectViewModel { };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole)]
        public async Task<IActionResult> CreateProject([FromForm]
        [Bind("ProjectName", "ProjectClient", "ProjectDescription", "ProjectPlannedStart", "ProjectPlannedEnd")]
        CreateProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                Project p = new Project { };
                p.ProjectName = model.ProjectName;
                p.ProjectClient = model.ProjectClient;
                p.ProjectDescription = model.ProjectDescription;
                p.ProjectPlannedStart = model.ProjectPlannedStart;
                p.ProjectPlannedEnd = model.ProjectPlannedEnd;
                p.ProjectCreatedByUser = user.UserName;

                var r = await _projectRepository.CreateProject(p);
                if (r != null)
                {
                    ViewData["success"] = "Nytt prosjekt er opprettet.";
                    return RedirectToAction("ViewProject", new { id = r });
                }
                else
                {
                    ViewData["error"] = "Noe gikk galt. Prøv igjen. Om feilen vedvarer, kontakt teknisk support.";
                    return View(model);
                }
            }
            else
            {
                TempData["error"] = "Feil med mottatt data. ModelStateInvalid!";
                return RedirectToAction("Index", null);
            }

        }

        [HttpGet]
        [Route("Project/DeleteProject/{id}")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole)]
        public async Task<IActionResult> DeleteProject([FromRoute] string id)
        {
            if (id != null)
            {
                string name = await _projectRepository.DeleteProjectAsync(id);
                if (name != null)
                {
                    TempData["success"] = string.Format("Prosjekt {0} er slettet!", name);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = string.Format("Prosjekt {0} er ikke slettet!", name);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["error"] = string.Format("Noe gikk galt. Kontakt teknisk support om det fortsetter.");
                return RedirectToAction("Index");
            }
        }

        ////////    ProjectCycle-functions     ////////
        [HttpGet]
        [Route("Project/ViewProjectCycle/{id}")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole + " , " + RoleOptions.MemberRole)]
        public async Task<IActionResult> ViewProjectCycle([FromRoute] string id)
        {
            ProjectCycle c = await _projectRepository.GetProjectCycleByUniqueId(id);

            ViewProjectCycleViewModel model = new ViewProjectCycleViewModel
            {
                ProjectCycle = c
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole)]
        public async Task<IActionResult> AddProjectCycle([FromForm]
        [Bind("projectId", "user", "cycleName", "cycleDescription", "startDate", "endDate")]
        ViewProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                AddProjectCycle c = new AddProjectCycle
                {
                    cycleName = model.cycleName,
                    cycleDescription = model.cycleDescription,
                    startDate = model.startDate,
                    endDate = model.endDate,
                    projectId = model.projectId,
                    user = model.user
                };
                var r = await _projectRepository.AddCycleToProjectAsync(c);
                if (r != null)
                {
                    TempData["success"] = "Ny syklus er lagt til.";
                    return RedirectToAction("ViewProject", new { id = model.projectId });
                }
                else
                {
                    TempData["error"] = "Noe gikk galt. Prøv igjen. Om feilen vedvarer, kontakt teknisk support.";
                    return RedirectToAction("ViewProject", new { id = model.projectId });
                }

            }
            else
            {
                TempData["error"] = "Feil med mottatt data. ModelStateInvalid!";
                return RedirectToAction("ViewProject", new { id = model.projectId });
            }

        }

        [HttpGet]
        [Route("Project/DeleteProjectCycle/{id}")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole)]
        public async Task<IActionResult> DeleteProjectCycle([FromRoute] string id)
        {
            if (id != null)
            {
                string projectUniqueId = await _projectRepository.DeleteProjectCycleAsync(id);
                if (projectUniqueId != null)
                {
                    TempData["success"] = string.Format("Syklus ble slettet!");
                    return RedirectToAction("Project", new { id = projectUniqueId });
                }
                else
                {
                    TempData["error"] = string.Format("Syklus ble ikke slettet!");
                    return RedirectToAction("Project", new { id = projectUniqueId });
                }
            }
            else
            {
                TempData["error"] = string.Format("Noe gikk galt. Kontakt teknisk support om det fortsetter.");
                return RedirectToAction("Index");
            }
        }

        ////////    ProjectCycleTask-functions    ////////
        [HttpGet]
        [Route("Project/ViewProjectCycleTask/{id}")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole + " , " + RoleOptions.MemberRole)]
        public async Task<IActionResult> ViewProjectCycleTask([FromRoute] string id)
        {
            ProjectCycleTask t = await _projectRepository.GetProjectCycleTaskByUniqueId(id);
            ProjectCycle c = await _projectRepository.GetProjectCycleByUniqueId(t.ProjectCycleId);
            Project p = await _projectRepository.GetProjectByUniqueId(c.ProjectId);

            ViewProjectCycleTaskViewModel model = new ViewProjectCycleTaskViewModel
            {
                ProjectCycleTask = t,
                ProjectCycle = c,
                Project = p
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole)]
        public async Task<IActionResult> AddCycleTask([FromForm]
        [Bind("tprojectCycleId", "user", "taskName", "taskDescription", "tplannedHours", "tdueDate")]
        ViewProjectCycleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AddProjectCycleTask t = new AddProjectCycleTask
                {
                    cycleTaskName = model.taskName,
                    cycleTaskDescription = model.taskDescription,
                    plannedHours = model.tplannedHours,
                    dueDate = model.tdueDate,
                    projectCycleId = model.tprojectCycleId,
                    user = model.user
                };
                var r = await _projectRepository.AddTaskToCycleAsync(t);
                if (r != null)
                {
                    TempData["success"] = "Ny oppgave er lagt til.";
                    return RedirectToAction("ViewProjectCycle", new { id = model.tprojectCycleId });
                }
                else
                {
                    TempData["error"] = "Noe gikk galt. Prøv igjen. Om feilen vedvarer, kontakt teknisk support.";
                    return RedirectToAction("ViewProjectCycle", new { id = model.tprojectCycleId });
                }

            }
            else
            {
                TempData["error"] = "Feil med mottatt data. ModelStateInvalid!";
                return RedirectToAction("ViewProjectCycle", new { id = model.tprojectCycleId });
            }

        }

        [HttpGet]
        [Route("Project/DeleteProjectCycleTask/{id}")]
        [Authorize(Roles = RoleOptions.AdminRole + "," + RoleOptions.TeamLeaderRole)]
        public async Task<IActionResult> DeleteProjectCycleTask([FromRoute] string id)
        {
            if (id != null)
            {
                string cycleUniqueId = await _projectRepository.DeleteProjectCycleTaskAsync(id);
                if (cycleUniqueId != null)
                {
                    TempData["success"] = string.Format("Oppgaven ble slettet!");
                    return RedirectToAction("Project/ViewProjectCycle", new { id = cycleUniqueId });
                }
                else
                {
                    TempData["error"] = string.Format("Oppgaven ble ikke slettet!");
                    return RedirectToAction("Project/ViewProjectCycle", new { id = cycleUniqueId });
                }
            }
            else
            {
                TempData["error"] = string.Format("Noe gikk galt. Kontakt teknisk support om det fortsetter.");
                return RedirectToAction("Index");
            }
        }

        

        
        
        

    }
}