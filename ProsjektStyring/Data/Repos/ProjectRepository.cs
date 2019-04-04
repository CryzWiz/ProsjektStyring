using Microsoft.AspNetCore.Identity;
using ProsjektStyring.Data;
using ProsjektStyring.Models.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.Repositorys
{
    public class ProjectRepository : IProjectRepository
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _db;

        public ProjectRepository(ApplicationDbContext db, UserManager<ApplicationUser> um)
        {
            _db = db;
            _userManager = um;
        }


        public async Task<string> CreateProject(Project project)
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            project.ProjectRegistered = DateTime.Now;
            project.Unique_ProjectIdString = GuidString;

            await _db.AddAsync(project);
            if (await _db.SaveChangesAsync() > 0) { return GuidString; }
            else return null;
        }


        public async Task<List<Project>> GetActiveProjectsAsync()
        {
            var projects = await Task.Run(() => _db.Project.Where(x => x.ProjectActive == true).ToList());
            return projects;
        }

        public async Task<List<Project>> GetCompletedProjectsAsync()
        {
            var projects = await Task.Run(() => _db.Project.Where(x => x.ProjectCompleted == true).ToList());
            return projects;
        }
    }
}
