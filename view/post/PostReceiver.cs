﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clyde.view.msg
{
    interface PostReceiver
    {
        void Receive(PostMsg message);
    }
}
