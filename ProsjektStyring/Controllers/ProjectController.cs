using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProsjektStyring.Data;
using ProsjektStyring.Models.IRepositorys;
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
        public async Task<IActionResult> CreateProject([FromForm][Bind("ProjectName","ProjectClient","ProjectDescription","ProjectPlannedStart","ProjectPlannedEnd")] CreateProjectViewModel model)
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
                    return RedirectToAction("ViewProject", new { id = r});
                }
                else
                {
                    ViewData["Error"] = "Noe gikk galt. Prøv igjen. Om feilen vedvarer, kontakt teknisk support.";
                    return View(model);
                }
            }
            else
            {
                ViewData["Error"] = "Noe gikk galt. Prøv igjen. Om feilen vedvarer, kontakt teknisk support.";
                return View(model);
            }
            
        }


    }
}