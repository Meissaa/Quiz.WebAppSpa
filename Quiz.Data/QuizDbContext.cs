using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Quiz.Common;
using Quiz.Common.Entities;

namespace Quiz.Data
{
    public partial class QuizDbContext : DbContext
    {
        public QuizDbContext()
            : base("QuizDbContext")
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Choice> Choices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>()
                .HasKey(e => e.UserId)
                .Property(e => e.UserId)
                .HasColumnName("UserId");

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .HasColumnName("Username")
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .HasColumnName("Password")
                .IsRequired();

            modelBuilder.Entity<Question>().HasRequired(e => e.User).WithMany().Map(m => m.MapKey("UserId"));

            modelBuilder.Entity<Question>().ToTable("Questions");
            modelBuilder.Entity<Question>()
                .HasKey(e => e.QuestionId)
                .Property(e => e.QuestionId)
                .HasColumnName("QuestionId");

            modelBuilder.Entity<Question>()
                .Property(e => e.QuestionText)
                .HasColumnName("Question")
                .IsRequired();

            modelBuilder.Entity<Question>().HasMany<Choice>(e => e.Choices).WithRequired(u => u.Question).Map(m => m.MapKey("QuestionId"));

            modelBuilder.Entity<Choice>().ToTable("Choices");
            modelBuilder.Entity<Choice>()
                .HasKey(e => e.ChoiceId)
                .Property(e => e.ChoiceId)
                .HasColumnName("ChoiceId");

            modelBuilder.Entity<Choice>()
                .Property(e => e.Answer)
                .HasColumnName("Choice")
                .IsRequired();

            modelBuilder.Entity<Choice>()
                .Property(e => e.IsCorrect)
                .HasColumnName("IsCorrect")
                .IsRequired();

            modelBuilder.Entity<Choice>().HasRequired(e => e.Question).WithMany(u=>u.Choices);
                

        }


    }
}
