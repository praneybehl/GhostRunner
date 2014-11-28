﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostRunner.Models
{
    public interface IContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Project> Projects { get; set; }

        IDbSet<Script> Scripts { get; set; }

        IDbSet<Task> Tasks { get; set; }

        IDbSet<TaskParameter> TaskParameters { get; set; }

        int SaveChanges();
    }
}