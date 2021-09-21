using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TofuWarrior.Storage
{
    public partial class TheTofuWarriorsDBContext : DbContext
    {
        public TheTofuWarriorsDBContext()
        {
        }

        public TheTofuWarriorsDBContext(DbContextOptions<TheTofuWarriorsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Following> Followings { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<MeasureUnit> MeasureUnits { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual DbSet<RecipeTag> RecipeTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRecipe> UserRecipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;database=TheTofuWarriorsDB;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment", "App");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CommentText)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PrevCommentId).HasColumnName("PrevCommentID");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.PrevComment)
                    .WithMany(p => p.InversePrevComment)
                    .HasForeignKey(d => d.PrevCommentId)
                    .HasConstraintName("FK_Comment_Comment");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Recipe");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<Following>(entity =>
            {
                entity.ToTable("Following", "App");

                entity.HasIndex(e => new { e.FollowerId, e.InfluencerId }, "UNQ_Following_FollowerID_InfluencerID")
                    .IsUnique();

                entity.Property(e => e.FollowingId).HasColumnName("FollowingID");

                entity.Property(e => e.FollowerId).HasColumnName("FollowerID");

                entity.Property(e => e.InfluencerId).HasColumnName("InfluencerID");

                entity.HasOne(d => d.Follower)
                    .WithMany(p => p.FollowingFollowers)
                    .HasForeignKey(d => d.FollowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Following_FollowerUser");

                entity.HasOne(d => d.Influencer)
                    .WithMany(p => p.FollowingInfluencers)
                    .HasForeignKey(d => d.InfluencerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Following_InfluencerUser");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredient", "App");

                entity.HasIndex(e => e.Name, "UNQ_Ingredient_Name")
                    .IsUnique();

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MeasureUnit>(entity =>
            {
                entity.ToTable("MeasureUnit", "App");

                entity.HasIndex(e => e.Unit, "UNQ_MeasureUnit_Name")
                    .IsUnique();

                entity.Property(e => e.MeasureUnitId).HasColumnName("MeasureUnitID");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating", "App");

                entity.HasIndex(e => new { e.UserId, e.RecipeId }, "UNQ_Rating_UserID_RecipeID")
                    .IsUnique();

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Recipe");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_User");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe", "App");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.CreatorUserId).HasColumnName("CreatorUserID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.CreatorUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_User");
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.ToTable("RecipeIngredient", "App");

                entity.Property(e => e.RecipeIngredientId).HasColumnName("RecipeIngredientID");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.MeasureUnitId).HasColumnName("MeasureUnitID");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecipeIngredient_Ingredient");

                entity.HasOne(d => d.MeasureUnit)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.MeasureUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecipeIngredient_MeasureUnit");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecipeIngredient_Recipe");
            });

            modelBuilder.Entity<RecipeTag>(entity =>
            {
                entity.ToTable("RecipeTag", "App");

                entity.HasIndex(e => new { e.TagId, e.RecipeId }, "UNQ_RecipeTag_TagID_RecipeID")
                    .IsUnique();

                entity.Property(e => e.RecipeTagId).HasColumnName("RecipeTagID");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeTags)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecipeTag_Recipe");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.RecipeTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecipeTag_Tag");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag", "App");

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "App");

                entity.HasIndex(e => e.Email, "UNQ_User_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UNQ_User_Username")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<UserRecipe>(entity =>
            {
                entity.ToTable("UserRecipe", "App");

                entity.Property(e => e.UserRecipeId).HasColumnName("UserRecipeID");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.UserRecipes)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_UserRecipe_Recipe");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRecipes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRecipe_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
