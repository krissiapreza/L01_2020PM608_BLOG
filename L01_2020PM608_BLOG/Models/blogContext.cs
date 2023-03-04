using Microsoft.EntityFrameworkCore;

namespace L01_2020PM608_BLOG.Models {
    public class blogContext:DbContext {

        public blogContext(DbContextOptions<blogContext>options): base(options) {

        }

        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<publicaciones> publicaciones { get; set; }
        public DbSet<comentarios> comentarios { get; set; }
    }
}
