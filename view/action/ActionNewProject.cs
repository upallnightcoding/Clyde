using Clyde.view.manager;
using Clyde.view.msg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clyde.view.action
{
    /// <summary>
    /// Class ActionNewProject -
    /// </summary>
    class ActionNewProject : Perform
    {
        // Class Constants
        //----------------
        private const string TITLE = "Create New Project";

        public ActionNewProject()
        {

        }

        /// <summary>
        /// Execute() - 
        /// </summary>
        public void Execute()
        {
            PostManager.Instance.Post(PostType.CREATE_PROJECT);
        }

        /// <summary>
        /// Title() - Return the title of the action.
        /// </summary>
        /// <returns></returns>
        public string Title()
        {
            return (TITLE);
        }
    }
}
