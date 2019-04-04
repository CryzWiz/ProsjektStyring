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

        public async Task<bool> CreateProject(Project project)
        {
            await _db.AddAsync(project);
            if (await _db.SaveChangesAsync() > 0) { return true; }
            else return false;
        }


        public Task<List<Project>> GetActiveProjectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> GetCompletedProjectsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
