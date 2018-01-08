using Nop.Core.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Tasks
{
    public partial class ScheduleTaskApiService : IScheduleTaskService
    {
        #region Methods

        /// <summary>
        /// Deletes a task
        /// </summary>
        /// <param name="task">Task</param>
        public virtual void DeleteTask(ScheduleTask task)
        {
            APIHelper.Instance.PostAsync("Tasks", "DeleteTask", task);
        }

        /// <summary>
        /// Gets a task
        /// </summary>
        /// <param name="taskId">Task identifier</param>
        /// <returns>Task</returns>
        public virtual ScheduleTask GetTaskById(int taskId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("taskId", taskId);
            return APIHelper.Instance.GetAsync<ScheduleTask>("Tasks", "GetTaskById", parameters);
        }

        /// <summary>
        /// Gets a task by its type
        /// </summary>
        /// <param name="type">Task type</param>
        /// <returns>Task</returns>
        public virtual ScheduleTask GetTaskByType(string type)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("type", type);
            return APIHelper.Instance.GetAsync<ScheduleTask>("Tasks", "GetTaskByType", parameters);
        }

        /// <summary>
        /// Gets all tasks
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Tasks</returns>
        public virtual IList<ScheduleTask> GetAllTasks(bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<ScheduleTask>("Tasks", "GetAllTasks", parameters);
        }

        /// <summary>
        /// Inserts a task
        /// </summary>
        /// <param name="task">Task</param>
        public virtual void InsertTask(ScheduleTask task)
        {
            APIHelper.Instance.PostAsync("Tasks", "InsertTask", task);
        }

        /// <summary>
        /// Updates the task
        /// </summary>
        /// <param name="task">Task</param>
        public virtual void UpdateTask(ScheduleTask task)
        {
            APIHelper.Instance.PostAsync("Tasks", "UpdateTask", task);
        }

        #endregion
    }
}
