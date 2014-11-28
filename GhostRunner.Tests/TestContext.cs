﻿using GhostRunner.Models;
using GhostRunner.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace GhostRunner.Tests
{
    public class TestContext : IContext
    {
        public IDbSet<User> Users { get; set; }

        public IDbSet<Project> Projects { get; set; }
        
        public IDbSet<Script> Scripts { get; set; }
        
        public IDbSet<Task> Tasks { get; set; }
        
        public IDbSet<TaskParameter> TaskParameters { get; set; }

        public TestContext()
        {
            Users = new TestDbSet<User>();
            Projects = new TestDbSet<Project>();
            Scripts = new TestDbSet<Script>();
            Tasks = new TestDbSet<Task>();
            TaskParameters = new TestDbSet<TaskParameter>();

            BuildUsers();
            BuildProjects();
            BuildScripts();
            BuildTasks();
        }

        private void BuildUsers()
        {
            User user1 = new User();
            user1.ID = 1;
            user1.ExternalId = "78597f62-553a-412b-ba0b-1ff71b1b7dae";
            user1.SessionId = "e36fbc0a-99b0-450c-83d7-9077820db7bc";
            user1.Name = "Test User 1";
            user1.Email = "test.user.1@gmail.com";
            user1.Password = EncryptionHelper.Hash("test", "SarahMcGowan");
            user1.IsAdminstrator = true;
            user1.Created = DateTime.Now;
            user1.Projects = new List<Project>();

            Users.Add(user1);

            User user2 = new User();
            user2.ID = 2;
            user2.ExternalId = "1dad8d7b-520c-4909-a3d0-a94ebf775752";
            user2.SessionId = "c91ee0d1-87fd-41fd-9db7-c865923e1c2c";
            user2.Name = "Test User 2";
            user2.Email = "test.user.2@gmail.com";
            user2.Password = EncryptionHelper.Hash("test", "SarahMcGowan");
            user2.IsAdminstrator = false;
            user2.Created = DateTime.Now;
            user2.Projects = new List<Project>();

            Users.Add(user2);

            User user3 = new User();
            user3.ID = 3;
            user3.ExternalId = "1cc3afed-c375-4ac3-a998-54f7c7a2ff3e";
            user3.SessionId = "f00026a5-3dba-453a-a9ca-12bd525477fb";
            user3.Name = "Test User 3";
            user3.Email = "test.user.3@gmail.com";
            user3.Password = EncryptionHelper.Hash("test", "SarahMcGowan");
            user3.IsAdminstrator = false;
            user3.Created = DateTime.Now;
            user3.Projects = new List<Project>();

            Users.Add(user3);
        }
    
        private void BuildProjects()
        {
            Project project1 = new Project();
            project1.ID = 1;
            project1.ExternalId = "d4708c0d-721e-426e-b49e-35990687db22";
            project1.Name = "Test Project 1";
            project1.Created = DateTime.Now;
            project1.Users = new List<User>();

            foreach (User user in Users.Where(u => u.ID == 1))
            {
                project1.Users.Add(user);
                user.Projects.Add(project1);
            }

            project1.Users = Users.Where(u => u.ID == 1).ToList();

            Projects.Add(project1);

            Project project2 = new Project();
            project2.ID = 2;
            project2.ExternalId = "bcc831de-ed6f-480b-a9dd-28de07fe7b19";
            project2.Name = "Test Project 2";
            project2.Created = DateTime.Now;
            project2.Users = new List<User>();

            foreach (User user in Users.Where(u => (u.ID == 1) || (u.ID == 2)))
            {
                project2.Users.Add(user);
                user.Projects.Add(project2);
            }

            Projects.Add(project2);
        }

        private void BuildScripts()
        {
            Script script1 = new Script();
            script1.ID = 1;
            script1.ExternalId = "5a768553-052e-47ee-bf48-68f8aaf9cd05";
            script1.Name = "Test Script 1";
            script1.Description = "Script used for testing";
            script1.Content = "Test script with [parameter1]";
            script1.Project = Projects.SingleOrDefault(p => p.ID == 1);

            Scripts.Add(script1);

            Script script2 = new Script();
            script2.ID = 2;
            script2.ExternalId = "8ebb4cf0-8e86-4773-9b0d-5ba86d2c0cce";
            script2.Name = "Test Script 2";
            script2.Description = "Another Script used for testing";
            script2.Content = "Test script with [parameter2]";
            script2.Project = Projects.SingleOrDefault(p => p.ID == 1);

            Scripts.Add(script2);
        }

        private void BuildTasks()
        {
            Task task1 = new Task();
            task1.ID = 1;
            task1.ExternalId = "352e3cf8-480b-4568-80b5-d0cba95dae04";
            task1.Name = "Test Script 1 Task";
            task1.Description = "Test task for script 1";
            task1.Content = "Test script with [parameter1]";
            task1.Status = Status.Completed;
            task1.Created = DateTime.Now.AddHours(-2);
            task1.Started = DateTime.Now.AddHours(-1);
            task1.Completed = DateTime.Now;
            task1.Log = "Output would go in here";
            task1.Script = Scripts.SingleOrDefault(s => s.ID == 1);
            task1.Content = "Test script with Added Parameter";
            task1.User = Users.SingleOrDefault(u => u.ID == 1);

            Tasks.Add(task1);

            TaskParameter taskParameter1 = new TaskParameter();
            taskParameter1.ID = 1;
            taskParameter1.Name = "parameter1";
            taskParameter1.Value = "Added Parameter";
            taskParameter1.Task = task1;

            TaskParameters.Add(taskParameter1);

            Task task2 = new Task();
            task2.ID = 2;
            task2.ExternalId = "b006de77-5937-486e-baff-f31877cb946e";
            task2.Name = "Test Script 2 Task";
            task2.Description = "Test task for script 2";
            task2.Content = "Test script with [parameter1]";
            task2.Status = Status.Unprocessed;
            task2.Created = DateTime.Now;
            task2.Started = null;
            task2.Completed = null;
            task2.Log = null;
            task2.Script = Scripts.SingleOrDefault(s => s.ID == 1);
            task2.Content = "Test script with Other Parameter";
            task2.User = Users.SingleOrDefault(u => u.ID == 1);

            Tasks.Add(task2);

            TaskParameter taskParameter2 = new TaskParameter();
            taskParameter2.ID = 2;
            taskParameter2.Name = "parameter1";
            taskParameter2.Value = "Other Parameter";
            taskParameter2.Task = task2;

            TaskParameters.Add(taskParameter2);
        }

        public int SaveChanges()
        {
            return -1;
        }
    }
}