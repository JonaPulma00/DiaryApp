using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<DiaryEntry>().HasData(
        //        new DiaryEntry
        //        {
        //            Id = new Guid("b7a2a6c0-9c8d-4f85-9c5e-70c62b1eb81c"),
        //            Title = "Cooked a meal",
        //            Content = "I cooked a meal for my family after a long time not seeing them",
        //            Created = new DateTime(2026, 1, 1, 12, 0, 0)
        //        },
        //        new DiaryEntry
        //        {
        //            Id = new Guid("f05605bd-321b-4a87-b3ff-74da1235b9f3"),
        //            Title = "Played chess with my friends",
        //            Content = "I've been practicing chess for 5 months so I decided to put my skills on work by playing chess with my friends.",
        //            Created = new DateTime(2026, 1, 1, 12, 0, 0)
        //        },
        //        new DiaryEntry
        //        {
        //            Id = new Guid("48ef1bc0-6d64-4965-8c86-6691628d6ff0"),
        //            Title = "Went swimming.",
        //            Content = "I went swimming with Paul.",
        //            Created = new DateTime(2026, 1, 1, 12, 0, 0)
        //        }
        //    );
        //}

        // Four steps to add a table
        // 1. Create a Model Class (done)
        // 2. Add DB Set
        // 3. add-migration AddDiaryEntryTable
        // 4. update-database

    }
}
