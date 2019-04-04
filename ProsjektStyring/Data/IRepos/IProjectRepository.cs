using ProsjektStyring.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.IRepositorys
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetActiveProjectsAsync();
        Task<List<Project>> GetCompletedProjectsAsync();
        Task<string> CreateProject(Project project);
    }
}
