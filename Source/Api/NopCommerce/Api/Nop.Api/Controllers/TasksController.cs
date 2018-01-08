using Nop.Core.Domain.Tasks;
using Nop.Services.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class TasksController : ApiController
    {
        #region Fields

        private readonly IScheduleTaskService _scheduleTaskService;

        #endregion

        #region Ctor

        public TasksController(IScheduleTaskService scheduleTaskService)
        {
            this._scheduleTaskService = scheduleTaskService;
        }

        #endregion

        #region Method

        #region ScheduleTask

        /// <summary>
        /// Deletes a task
        /// </summary>
        /// <param name="task">Task</param>
        public void DeleteTask([FromBody]ScheduleTask task)
        {
            _scheduleTaskService.DeleteTask(task);
        }

        /// <summary>
        /// Gets a task
        /// </summary>
        /// <param name="taskId">Task identifier</param>
        /// <returns>Task</returns>
        public ScheduleTask GetTaskById(int taskId)
        {
            return _scheduleTaskService.GetTaskById(taskId);
        }

        /// <summary>
        /// Gets a task by its type
        /// </summary>
        /// <param name="type">Task type</param>
        /// <returns>Task</returns>
        public ScheduleTask GetTaskByType(string type)
        {
            return _scheduleTaskService.GetTaskByType(type);
        }

        /// <summary>
        /// Gets all tasks
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Tasks</returns>
        public IList<ScheduleTask> GetAllTasks(bool showHidden = false)
        {
            return _scheduleTaskService.GetAllTasks(showHidden);
        }

        /// <summary>
        /// Inserts a task
        /// </summary>
        /// <param name="task">Task</param>
        public void InsertTask([FromBody]ScheduleTask task)
        {
            _scheduleTaskService.InsertTask(task);
        }

        /// <summary>
        /// Updates the task
        /// </summary>
        /// <param name="task">Task</param>
        public void UpdateTask([FromBody]ScheduleTask task)
        {
            _scheduleTaskService.UpdateTask(task);
        }

        #endregion

        #endregion
    }
}
