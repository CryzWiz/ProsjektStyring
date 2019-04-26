using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProsjektStyring.Data;
using ProsjektStyring.Models.IRepositorys;
using ProsjektStyring.Models.ProjectApiControllerModels;
using ProsjektStyring.Models.ProjectControllerModels;
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

        ///////////////                //////////////
        ///////////////     Project    //////////////
        ///////////////                //////////////
        public async Task<string> CreateProject(AddProject project)
        {
            Project p = new Project { };
            p.ProjectName = project.ProjectName;
            p.ProjectClient = project.ProjectClient;
            p.ProjectDescription = project.ProjectDescription;
            p.ProjectPlannedStart = project.ProjectPlannedStart;
            p.ProjectPlannedEnd = project.ProjectPlannedEnd;
            p.ProjectCreatedByUser = project.ProjectCreatedByUser;

            p.ProjectRegistered = DateTime.Now;
            p.Unique_ProjectIdString = getGuid();
           
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
            p.ProjectCycles = initList;
            p.NumberOfProjectCycles = initList.Count;

            _db.Project.Add(p);
            if (await _db.SaveChangesAsync() > 0)
            {

                return p.Unique_ProjectIdString;
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
        public async Task<Project> GetProjectByUniqueId(int id)
        {
            var project = await Task.Run(() => _db.Project.FirstOrDefault(x => x.ProjectId == id));
            return project;
        }
        // TODO: Edit all updates correct -ie comleted, active...
        public async Task<bool> EditProjectAsync(EditProject project)
        {
            Project p = await GetProjectByUniqueId(project.Unique_ProjectIdString);

            if (project.ProjectName != p.ProjectName) p.ProjectName = project.ProjectName;
            if (project.ProjectClient != p.ProjectClient) p.ProjectClient = project.ProjectClient;
            if (project.ProjectDescription != p.ProjectDescription) p.ProjectDescription = project.ProjectDescription;
            if (project.ProjectActive != p.ProjectActive) p.ProjectActive = project.ProjectActive;
            if (project.ProjectCompleted != p.ProjectCompleted) p.ProjectCompleted = project.ProjectCompleted;
            if (project.ProjectPlannedEnd != p.ProjectPlannedEnd) p.ProjectPlannedEnd = project.ProjectPlannedEnd;
            if (project.ProjectPlannedStart != p.ProjectPlannedStart) p.ProjectPlannedStart = project.ProjectPlannedStart;

            _db.Update(p);
            if (await _db.SaveChangesAsync() > 0)
            {
                return true;
            }
            else return false;
        }
        public async Task<string> DeleteProjectAsync(string unique_id)
        {
            Project p = await GetProjectByUniqueId(unique_id);
            if (p != null)
            {
                string name = p.ProjectName;
                _db.RemoveRange(p);
                if (await _db.SaveChangesAsync() > 0)
                {
                    return name;
                }
                else return null;
            }
            else return null;
        }

        ///////////////                     //////////////
        ///////////////     ProjectCycle    //////////////
        ///////////////                     //////////////
        public async Task<ProjectCycle> GetProjectCycleByUniqueId(string id)
        {
            var cycle = await _db.ProjectCycle.Include("ProjectCycleTasks").Include("ProjectCycleComments").FirstOrDefaultAsync(x => x.Unique_CycleIdString == id);
            var p = await _db.Project.FirstOrDefaultAsync(x => x.ProjectId == cycle.ProjectId);
            cycle.Project = p;
            return cycle;
        }
        public async Task<ProjectCycle> GetProjectCycleByUniqueId(int id)
        {
            var cycle = await _db.ProjectCycle.FirstOrDefaultAsync(x => x.ProjectCycleId == id);
            var p = await _db.Project.FirstOrDefaultAsync(x => x.ProjectId == cycle.ProjectId);
            cycle.Project = p;
            return cycle;
        }
        public async Task<string> DeleteProjectCycleAsync(string unique_id)
        {
            ProjectCycle c = await GetProjectCycleByUniqueId(unique_id);
            if (c != null)
            {
                string projectUniqueId = await getProjectCycleId(c.ProjectId);
                _db.RemoveRange(c);
                if (await _db.SaveChangesAsync() > 0)
                {
                    return projectUniqueId;
                }
                else return null;
            }
            else return null;
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
            if (await _db.SaveChangesAsync() > 0)
            {
                ProjectCycle newCycle = await GetProjectCycleByUniqueId(c.Unique_CycleIdString);
                return newCycle;
            }
            else
            {
                return null;
            }
        }
        // TODO: Edit all updates correct -ie comleted, active...
        public async Task<bool> EditProjectCycleAsync(EditProjectCycle pC)
        {
            ProjectCycle c = await GetProjectCycleByUniqueId(pC.unique_CycleIdString);

            if (pC.cycleActive != c.CycleActive) c.CycleActive = pC.cycleActive;
            if (pC.cycleDescription != c.CycleDescription) c.CycleDescription = pC.cycleDescription;
            if (pC.cycleFinished != c.CycleFinished) c.CycleFinished = pC.cycleFinished;
            if (pC.cycleName != c.CycleName) c.CycleName = pC.cycleName;
            if (pC.endDate != c.CyclePlannedEnd) c.CyclePlannedEnd = pC.endDate;
            if (pC.startDate != c.CyclePlannedStart) c.CyclePlannedStart = pC.startDate;

            _db.Update(c);
            if (await _db.SaveChangesAsync() > 0)
            {
                return true;
            }
            else return false;
        }



        ///////////////                         ///////////////
        ///////////////     ProjectCycleTask    ///////////////
        ///////////////                         ///////////////
        public async Task<ProjectCycleTask> GetProjectCycleTaskByUniqueId(string id)
        {
            ProjectCycleTask task = await _db.ProjectCycleTask.Include("ProjectCycleTaskComments").FirstOrDefaultAsync(x => x.Unique_TaskIdString == id);
            return task;
        }
        public async Task<ProjectCycleTask> GetProjectCycleTaskByUniqueId(int id)
        {
            ProjectCycleTask task = await _db.ProjectCycleTask.FirstOrDefaultAsync(x => x.ProjectCycleTaskId == id);
            return task;
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
        public async Task<string> DeleteProjectCycleTaskAsync(string unique_id)
        {
            ProjectCycleTask t = await GetProjectCycleTaskByUniqueId(unique_id);
            if (t != null)
            {
                string cycleUniqueId = await getProjectCycleId(t.ProjectCycleTaskId);
                _db.RemoveRange(t);
                if (await _db.SaveChangesAsync() > 0)
                {
                    return cycleUniqueId;
                }
                else return null;
            }
            else return null;
        }
        // TODO: Edit all updates correct -ie comleted, active...
        public async Task<bool> EditProjectCycleTaskAsync(EditProjectCycleTask task)
        {
            ProjectCycleTask c = await GetProjectCycleTaskByUniqueId(task.unique_TaskIdString);

            if (task.cycleTaskName != c.TaskName) c.TaskName = task.cycleTaskName;
            if (task.cycleTaskDescription != c.TaskDescription) c.TaskDescription = task.cycleTaskDescription;
            if (task.plannedHours != c.PlannedHours) c.PlannedHours = task.plannedHours;
            if (task.dueDate != c.TaskDueDate) c.TaskDueDate = task.dueDate;
            if (task.taskActive != c.TaskActive) c.TaskActive = task.taskActive;
            _db.Update(c);
            if (await _db.SaveChangesAsync() > 0)
            {
                return true;
            }
            else return false;
        }


        ////////////////                        ////////////////
        ////////////////        Comments        ////////////////
        // Are divided in 3 just in case we want to make the  //
        // comment-sections different. Information etc..      //
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
                return comment;
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
                return comment;
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
                return comment;
            }
            else return null;
        }


        ///////////////                         ///////////////
        ///////////////     Private Helpers     ///////////////
        ///////////////                         ///////////////
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
        private async Task<string> getProjectId(int id)
        {
            var p = await _db.Project.FirstOrDefaultAsync(x => x.ProjectId == id);
            return p.Unique_ProjectIdString;
        }
        private async Task<int> getProjectCycleId(string uniqueId)
        {
            var c = await _db.ProjectCycle.FirstOrDefaultAsync(x => x.Unique_CycleIdString == uniqueId);
            return c.ProjectCycleId;
        }
        private async Task<string> getProjectCycleId(int id)
        {
            var c = await _db.ProjectCycle.FirstOrDefaultAsync(x => x.ProjectCycleId == id);
            return c.Unique_CycleIdString;
        }
        private async Task<int> getProjectCycleTaskId(string uniqueId)
        {
            var c = await _db.ProjectCycleTask.FirstOrDefaultAsync(x => x.Unique_TaskIdString == uniqueId);
            return c.ProjectCycleTaskId;
        }
        private async Task<string> getProjectCycleTaskId(int id)
        {
            var c = await _db.ProjectCycleTask.FirstOrDefaultAsync(x => x.ProjectCycleTaskId == id);
            return c.Unique_TaskIdString;
        }

      
    }
}
