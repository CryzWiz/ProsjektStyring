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

        // Getters for Project by status
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

        // Getters for Project, ProjectCycle and ProjectCycleTask by unique id string and id
        // UniqueId methods returns all containing underclasses 
        // -> Project inluces Cycles and Comments. 
        // -> ProjectCycles includes Tasks and Comments
        // -> ProjectCycleTasks includes Comments
        // Fetching by int ID only returns single entity
        public async Task<Project> GetProjectByUniqueId(string id)
        {
            var project = await Task.Run(() => _db.Project.Include("ProjectCycles").Include("ProjectComments").FirstOrDefault(x => x.Unique_ProjectIdString == id));
            return project;
        }
        public async Task<ProjectCycle> GetProjectCycleByUniqueId(string id)
        {
            var cycle = await _db.ProjectCycle.Include("ProjectCycleTasks").Include("ProjectCycleComments").FirstOrDefaultAsync(x => x.Unique_CycleIdString == id);
            var p = await _db.Project.FirstOrDefaultAsync(x => x.ProjectId == cycle.ProjectId);
            cycle.Project = p;
            return cycle;
        }
        public async Task<ProjectCycleTask> GetProjectCycleTaskByUniqueId(string id)
        {
            ProjectCycleTask task = await _db.ProjectCycleTask.Include("ProjectCycleTaskComments").FirstOrDefaultAsync(x => x.Unique_TaskIdString == id);
            return task;
        }
        public async Task<Project> GetProjectByUniqueId(int id)
        {
            var project = await Task.Run(() => _db.Project.FirstOrDefault(x => x.ProjectId == id));
            return project;
        }
        public async Task<ProjectCycle> GetProjectCycleByUniqueId(int id)
        {
            var cycle = await _db.ProjectCycle.FirstOrDefaultAsync(x => x.ProjectCycleId == id);
            var p = await _db.Project.FirstOrDefaultAsync(x => x.ProjectId == cycle.ProjectId);
            cycle.Project = p;
            return cycle;
        }
        public async Task<ProjectCycleTask> GetProjectCycleTaskByUniqueId(int id)
        {
            ProjectCycleTask task = await _db.ProjectCycleTask.FirstOrDefaultAsync(x => x.ProjectCycleTaskId == id);
            return task;
        }

        // Adders for Project, ProjectCycle and ProjectCycleTask
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
        public async Task<ProjectCycleTask> AddTaskToCycleAsync(AddProjectCycleTask cT)
        {

            ProjectCycleTask t = new ProjectCycleTask { };
            t.ProjectCycleId = await getProjectCycleId(cT.projectCycleId);
            t.TaskActive = false;
            t.TaskDescription = cT.cycleTaskDescription;
            t.TaskName = cT.cycleTaskName;
            t.PlannedHours = cT.plannedHours;
            t.TaskCompleted = false;
            t.TotalHoursSpent = 0.0;
            t.TaskRegistered = DateTime.Now;
            t.TaskDueDate = cT.dueDate;
            t.Unique_TaskIdString = getGuid();

            _db.Add(t);
            if (await _db.SaveChangesAsync() > 0)
            {
                ProjectCycleTask newTaske = await GetProjectCycleTaskByUniqueId(t.Unique_TaskIdString);
                return newTaske;
            }
            else
            {
                return null;
            }
        }

        // Comments controlls
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
        public async Task<ProjectCycleComment> AddProjectCycleCommentAsync(AddProjectCycleComment pC)
        {
            ProjectCycleComment comment = new ProjectCycleComment
            {
                CommentRegistered = DateTime.Now,
                ByUser = pC.user,
                Comment = pC.comment,
                CommentHeading = pC.commentHeading,
                ProjectCycleId = await getProjectCycleId(pC.projectCycleId),
                Unique_IdString = getGuid()
            };
            _db.Add(comment);
            if (await _db.SaveChangesAsync() > 0)
            {
                var c = await _db.ProjectCycleComment.FirstOrDefaultAsync(x => x.Unique_IdString == comment.Unique_IdString);
                return c;
            }
            else return null;
        }
        public async Task<ProjectCycleTaskComment> AddProjectCycleTaskCommentAsync(AddProjectCycleTaskComment pC)
        {
            ProjectCycleTaskComment comment = new ProjectCycleTaskComment
            {
                CommentRegistered = DateTime.Now,
                ByUser = pC.user,
                Comment = pC.comment,
                CommentHeading = pC.commentHeading,
                ProjectCycleTaskId = await getProjectCycleTaskId(pC.projectCycleTaskId),
                Unique_IdString = getGuid()
            };
            _db.Add(comment);
            if (await _db.SaveChangesAsync() > 0)
            {
                var c = await _db.ProjectCycleTaskComment.FirstOrDefaultAsync(x => x.Unique_IdString == comment.Unique_IdString);
                return c;
            }
            else return null;
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

        private async Task<int> getProjectCycleId(string uniqueId)
        {
            var c = await _db.ProjectCycle.FirstOrDefaultAsync(x => x.Unique_CycleIdString == uniqueId);
            return c.ProjectCycleId;
        }

        private async Task<int> getProjectCycleTaskId(string uniqueId)
        {
            var c = await _db.ProjectCycleTask.FirstOrDefaultAsync(x => x.Unique_TaskIdString == uniqueId);
            return c.ProjectCycleId;
        }


    }
}
