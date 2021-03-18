using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clyde.view.msg
{
    class MsgPost
    {
        // Message type that is being posted
        public MsgPostType Type { get; set; } = MsgPostType.UNKNOWN;

        // Additional data carried with message
        public object Dto { get; set; } = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public MsgPost(MsgPostType type)
        {

        }

        public MsgPost(MsgPostType type, object dto)
        {
            Type = type;
            Dto = dto;
        }
    }
}
