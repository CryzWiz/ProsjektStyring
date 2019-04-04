using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProsjektStyring.Data;
using ProsjektStyring.Models.IRepositorys;
using ProsjektStyring.Models.ProjectControllerModels;

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
        public async Task<IActionResult> Index()
        {
            IndexViewModel model = new IndexViewModel
            {
                ActiveProjects = await _projectRepository.GetActiveProjectsAsync(),
                CompletedProjects = await _projectRepository.GetCompletedProjectsAsync()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            CreateProjectViewModel model = new CreateProjectViewModel { };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromForm]
        [Bind("ProjectName","ProjectClient","ProjectDescription","ProjectPlannedStart","ProjectPlannedEnd")] CreateProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                var p = new Project
                {
                    ProjectName = model.ProjectName,
                    ProjectClient = model.ProjectClient,
                    ProjectDescription = model.ProjectDescription,
                    ProjectPlannedStart = model.ProjectPlannedStart,
                    ProjectPlannedEnd = model.ProjectPlannedEnd,
                    ProjectCreatedByUser = user.UserName
                };
                var r = await _projectRepository.CreateProject(p);
                if (r != null)
                {
                    return RedirectToAction("ProjectSetup", new { id = r});
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