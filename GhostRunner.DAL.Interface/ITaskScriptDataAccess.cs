﻿using GhostRunner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GhostRunner.DAL.Interface
{
    public interface ITaskScriptDataAccess
    {
        TaskScript Get(int taskScriptId);

        TaskScript Insert(TaskScript taskScript);
    }
}
