using Microsoft.EntityFrameworkCore;

namespace VideoAPIWebApp.Models
{
    public class VideoAPIContext : DbContext
    {
        public virtual DbSet<Blogger> Bloggers { get; set; }
        public virtual DbSet<BloggerChannel> BloggerChannels { get; set; }
        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        public VideoAPIContext(DbContextOptions<VideoAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
