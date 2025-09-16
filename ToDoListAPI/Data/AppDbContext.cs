using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Interfaces;

using ToDoListAPI.Interfaces.Models;

namespace ToDoListAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<IToDoList> ToDoLists { get; set; }
    }
}
