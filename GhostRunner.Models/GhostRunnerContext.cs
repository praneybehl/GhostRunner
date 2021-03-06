﻿using GhostRunner.Models;
using GhostRunnerMaker.Models.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostRunner.Models
{
    public class GhostRunnerContext : DbContext, IContext
    {
        public GhostRunnerContext(string connectionString)
            : base(connectionString)
        {
            Configuration.AutoDetectChangesEnabled = true;
            Database.SetInitializer<GhostRunnerContext>(new MigrateDatabaseToLatestVersion<GhostRunnerContext, Configuration>(connectionString));
        }
        
        public IDbSet<User> Users { get; set; }

        public IDbSet<Project> Projects { get; set; }

        public IDbSet<Sequence> Sequences { get; set; }

        public IDbSet<SequenceScript> SequenceScripts { get; set; }

        public IDbSet<ScheduleDetail> ScheduleDetails { get; set; }

        public IDbSet<Script> Scripts { get; set; }

        public IDbSet<Task> Tasks { get; set; }

        public IDbSet<TaskScript> TaskScripts { get; set; }

        public IDbSet<TaskScriptParameter> TaskScriptParameters { get; set; }

        public IDbSet<Schedule> Schedules { get; set; }

        public IDbSet<ScheduleParameter> ScheduleParameters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
