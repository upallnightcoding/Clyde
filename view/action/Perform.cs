using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clyde.view.action
{
    interface Perform
    {
        /// <summary>
        /// Execute() - 
        /// </summary>
        void Execute();

        /// <summary>
        /// Title() - 
        /// </summary>
        /// <returns></returns>
        string Title();
    }
}
