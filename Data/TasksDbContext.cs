using Microsoft.EntityFrameworkCore;
using Net5Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5Api.Data
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options)
        {

        }

        public DbSet<MyTask> Tasks { get; set; }

    }
}
