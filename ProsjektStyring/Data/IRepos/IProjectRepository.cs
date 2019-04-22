using ProsjektStyring.Data;
using ProsjektStyring.Models.ProjectApiControllerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.IRepositorys
{
    public interface IProjectRepository
    {
        Task<Project> GetProjectByUniqueId(string id);
        Task<List<Project>> GetUnActivatedProjectsAsync();
        Task<List<Project>> GetActiveProjectsAsync();
        Task<List<Project>> GetCompletedProjectsAsync();
        Task<string> CreateProject(Project project);
        Task<ProjectCycle> AddCycleToProjectAsync(AddProjectCycle pC);
    }
}
