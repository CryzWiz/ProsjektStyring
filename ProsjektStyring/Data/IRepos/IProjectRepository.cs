using ProsjektStyring.Data;
using ProsjektStyring.Models.ProjectApiControllerModels;
using ProsjektStyring.Models.ProjectControllerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.IRepositorys
{
    public interface IProjectRepository
    {
        ///////////////                //////////////
        ///////////////     Project    //////////////
        ///////////////                //////////////
        /// <summary>
        /// Find and return all UnActivated Projects in the Db
        /// </summary>
        Task<List<Project>> GetUnActivatedProjectsAsync();
        /// <summary>
        /// Find and return all Active Projects in the Db
        /// </summary>
        Task<List<Project>> GetActiveProjectsAsync();
        /// <summary>
        /// Find and return all Completed Projects in the Db
        /// </summary>
        Task<List<Project>> GetCompletedProjectsAsync();
        /// <summary>
        /// Returns the Project with all cycles, tasks and comments.
        /// Takes the UniqueId string. Returns null if nothing is found.
        /// Uses .Include() in EF
        /// </summary>
        Task<Project> GetProjectByUniqueId(string id);
        /// <summary>
        /// Takes the ProjectId and returns the Project if found. 
        /// Else it returns null.
        /// </summary>
        Task<Project> GetProjectByUniqueId(int id);
        /// <summary>
        /// Creates a new project in the database, and returns the Unique_id for that
        /// project if ok, else it will return null.
        /// </summary>
        Task<string> CreateProject(AddProject project);
        /// <summary>
        /// Delete given Project and all corresponding data.
        /// Return name for Project if ok. Null if not ok.
        /// Also deletes comments to this entity and sub-entitys.
        /// </summary>
        Task<string> DeleteProjectAsync(string unique_id);
        /// <summary>
        /// Updates the given Project, and returns true if updated,
        /// false if not.
        /// </summary>
        Task<bool> EditProjectAsync(EditProject project);


        ///////////////                     //////////////
        ///////////////     ProjectCycle    //////////////
        ///////////////                     //////////////
        Task<bool> EditProjectCycleAsync(EditProjectCycle pC);
        /// <summary>
        /// Takes the ProjectCycleId and returns the
        /// ProjectCycle if found. Else it returns null
        /// </summary>
        Task<ProjectCycle> GetProjectCycleByUniqueId(int id);
        /// <summary>
        /// Returns the cycle with all tasks and comments.
        /// Takes the UniqueId string. Returns null if nothing is found.
        /// Uses .Include() in EF
        /// </summary>
        Task<ProjectCycle> GetProjectCycleByUniqueId(string id);
        
        /// <summary>
        /// Takes a AddProjectCycle object, converts it to a ProjectCycle
        /// and adds it to the right Project. Returns the new ProjectCycle
        /// if ok, else it will return null.
        /// </summary>
        Task<ProjectCycle> AddCycleToProjectAsync(AddProjectCycle pC);
        /// <summary>
        /// Delete given ProjectCycle and all corresponding data.
        /// Return Unique_StringId for Project the ProjectCycle belongs to if ok.
        /// Null if not ok.
        /// Also deletes comments to this entity and sub-entitys.
        /// </summary>
        Task<string> DeleteProjectCycleAsync(string unique_id);


        ///////////////                         ///////////////
        ///////////////     ProjectCycleTask    ///////////////
        ///////////////                         ///////////////
        Task<bool> EditProjectCycleTaskAsync(EditProjectCycleTask task);
        /// <summary>
        /// Takes the ProjectCycleTaskId and returns the
        /// ProjectCycleTask if found. Else it returns null
        /// </summary>
        Task<ProjectCycleTask> GetProjectCycleTaskByUniqueId(int id);
        /// <summary>
        /// Returns the task with all comments.
        /// Takes the UniqueId string. Returns null if nothing is found.
        /// Uses .Include() in EF
        /// </summary>
        Task<ProjectCycleTask> GetProjectCycleTaskByUniqueId(string id);
        /// <summary>
        /// Takes a AddProjectCycleTask object, converts it to a ProjectCycleTask
        /// and adds it to the right ProjectCycle. Returns the new ProjectCycleTask
        /// if ok, else it will return null.
        /// </summary>
        Task<ProjectCycleTask> AddTaskToCycleAsync(AddProjectCycleTask cT);       
        /// <summary>
        /// Delete given ProjectCycleTask and all corresponding data.
        /// Return Unique_StringId for ProjectCycle the ProjectCycleTask belongs to if ok.
        /// Null if not ok.
        /// Also deletes comments to this entity.
        /// </summary>
        Task<string> DeleteProjectCycleTaskAsync(string unique_id);


        ////////////////                        ////////////////
        ////////////////        Comments        ////////////////
        // Are divided in 3 just in case we want to make the  //
        // comment-sections different. Information etc..      //
        /// <summary>
        /// Takes a AddProjectComment object, converts it to a ProjectComment
        /// and adds it to the right Project. Returns the new ProjectComment
        /// if ok, else it will return null.
        /// </summary>
        Task<ProjectComment> AddProjectCommentAsync(AddProjectComment pC);
        /// <summary>
        /// Takes a AddProjectCycleComment object, converts it to a ProjectCycleComment
        /// and adds it to the right ProjectCycle. Returns the new ProjectCyleComment
        /// if ok, else it will return null.
        /// </summary>
        Task<ProjectCycleComment> AddProjectCycleCommentAsync(AddProjectCycleComment pC);
        /// <summary>
        /// Takes a AddProjectCycleTaskComment object, converts it to a ProjectCycleTaskComment
        /// and adds it to the right ProjectCycleTask. Returns the new ProjectCyleTaskComment
        /// if ok, else it will return null.
        /// </summary>
        Task<ProjectCycleTaskComment> AddProjectCycleTaskCommentAsync(AddProjectCycleTaskComment pC);
    }
}
