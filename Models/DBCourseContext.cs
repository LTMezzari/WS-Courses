using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ws_courses.Models {
    public class DBCourseContext: DbContext {
        
        public DBCourseContext(): base("DBCourses") {
        }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}