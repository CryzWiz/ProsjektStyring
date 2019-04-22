using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProsjektStyring.Data;
using ProsjektStyring.Models.IRepositorys;
using ProsjektStyring.Models.ProjectApiControllerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.Repositorys
{
    public class ProjectRepository : IProjectRepository
    {

        private ApplicationDbContext _db;

        public ProjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<string> CreateProject(Project project)
        {

            project.ProjectRegistered = DateTime.Now;
            project.Unique_ProjectIdString = getGuid();
           
            ProjectCycle initCycle = new ProjectCycle
            {
                CycleName = "Mine Oppgaver",
                CycleRegistered = DateTime.Now,
                Unique_CycleIdString = getGuid(),
                CycleNumber = 1,
                CyclePlannedStart = project.ProjectPlannedStart,
                CyclePlannedEnd = project.ProjectPlannedEnd,
                CycleDescription = "Du kan opprette alle oppgaver under denne syklusen, eller du kan lage flere sykluser. Hver syklus kan ha mange arbeidsoppgaver."
            };

            List<ProjectCycle> initList = new List<ProjectCycle>();
            initList.Add(initCycle);
            project.ProjectCycles = initList;
            project.NumberOfProjectCycles = initList.Count;

            await _db.AddAsync(project);
            if (await _db.SaveChangesAsync() > 0)
            {

                return project.Unique_ProjectIdString;
            }
            else return null;
        }

        public async Task<List<Project>> GetActiveProjectsAsync()
        {
            var projects = await Task.Run(() => _db.Project.Where(x => x.ProjectActive == true).ToList());
            return projects;
        }

        public async Task<List<Project>> GetUnActivatedProjectsAsync()
        {
            var projects = await Task.Run(() => _db.Project.Where(x => x.ProjectActive == false && x.ProjectCompleted == false).ToList());
            return projects;
        }

        public async Task<List<Project>> GetCompletedProjectsAsync()
        {
            var projects = await Task.Run(() => _db.Project.Where(x => x.ProjectCompleted == true).ToList());
            return projects;
        }

        public async Task<Project> GetProjectByUniqueId(string id)
        {
            var project = await Task.Run(() => _db.Project.Include("ProjectCycles").Include("ProjectComments").FirstOrDefault(x => x.Unique_ProjectIdString == id));
            return project;
        }

        public async Task<ProjectCycle> GetProjectCycleByUniqueId(string id)
        {
            var cycle = await Task.Run(() => _db.ProjectCycle.FirstOrDefault(x => x.Unique_CycleIdString == id));
            var p = await _db.Project.FirstOrDefaultAsync(x => x.ProjectId == cycle.ProjectId);
            cycle.Project = p;
            return cycle;
        }

        public async Task<ProjectCycle> AddCycleToProjectAsync(AddProjectCycle pC)
        {
            Project p = await GetProjectByUniqueId(pC.projectId);
            p.NumberOfProjectCycles = p.NumberOfProjectCycles + 1;

            ProjectCycle c = new ProjectCycle { };
            c.ProjectId = p.ProjectId;
            c.CycleActive = false;
            c.CycleDescription = pC.cycleDescription;
            c.CycleName = pC.cycleName;
            c.CycleNumber = p.NumberOfProjectCycles;
            c.CyclePlannedStart = pC.startDate;
            c.CyclePlannedEnd = pC.endDate;
            c.CycleRegistered = DateTime.Now;
            c.Unique_CycleIdString = getGuid();

            p.ProjectCycles.Add(c);
            _db.Update(p);
            if(await _db.SaveChangesAsync() > 0)
            {
                ProjectCycle newCycle = await GetProjectCycleByUniqueId(c.Unique_CycleIdString);
                return newCycle;
            }
            else
            {
                return null;
            }
        }

        public async Task<ProjectComment> AddProjectCommentAsync(AddProjectComment pC)
        {
            
            ProjectComment comment = new ProjectComment
            {
                CommentRegistered = DateTime.Now,
                ByUser = pC.user,
                Comment = pC.comment,
                CommentHeading = pC.commentHeading,
                ProjectId = await getProjectId(pC.projectId),
                Unique_IdString = getGuid()
            };
            _db.Add(comment);
            if (await _db.SaveChangesAsync() > 0)
            {
                var c = await _db.ProjectComment.FirstOrDefaultAsync(x => x.Unique_IdString == comment.Unique_IdString);
                return c;
            }
            else return null;
        }

        public Task<ProjectCycleComment> AddProjectCycleCommentAsync(AddProjectCycleComment pC)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectCycleTask> AddTaskToCycleAsync(AddProjectCycleTask cT)
        {
            throw new NotImplementedException();
        }

        /// Helpers
        /// 
        private string getGuid()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");
            GuidString = GuidString.Replace("\\", "");
            GuidString = GuidString.Replace("-", "");
            return GuidString;
        }

        private async Task<int> getProjectId(string uniqueId)
        {
            var p = await _db.Project.FirstOrDefaultAsync(x => x.Unique_ProjectIdString == uniqueId);
            return p.ProjectId;
        }

       
    }
}
