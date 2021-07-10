using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clyde.view.msg
{
    class PostMsg
    {
        // Message type that is being posted
        public PostType Type { get; set; } = PostType.UNKNOWN;

        // Additional data carried with message
        public object Dto { get; set; } = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public PostMsg(PostType type) : this(type, null)
        {
            
        }

        public PostMsg(PostType type, object dto)
        {
            Type = type;
            Dto = dto;
        }
    }
}
