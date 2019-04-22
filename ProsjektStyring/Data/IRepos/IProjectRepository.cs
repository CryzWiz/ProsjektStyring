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
        // Fetchers
        Task<Project> GetProjectByUniqueId(string id);
        Task<ProjectCycle> GetProjectCycleByUniqueId(string id);

        // Projects
        Task<List<Project>> GetUnActivatedProjectsAsync();
        Task<List<Project>> GetActiveProjectsAsync();
        Task<List<Project>> GetCompletedProjectsAsync();

        Task<string> CreateProject(Project project);

        // Cycles
        Task<ProjectCycle> AddCycleToProjectAsync(AddProjectCycle pC);


        // Comments
        Task<ProjectComment> AddProjectCommentAsync(AddProjectComment pC);
    }
}
