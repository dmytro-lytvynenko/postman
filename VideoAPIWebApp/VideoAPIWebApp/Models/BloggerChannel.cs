using System.ComponentModel.DataAnnotations;

namespace VideoAPIWebApp.Models
{
    public class BloggerChannel
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public int BloggerId { get; set; }
        public virtual Blogger Blogger { get; set; }
        public virtual Channel Channel { get; set; }
    }
}