using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProsjektStyring.Models.IRepositorys;

namespace ProsjektStyring.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository Pr)
        {
            _projectRepository = Pr;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}