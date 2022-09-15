using System.ComponentModel.DataAnnotations;

namespace VideoAPIWebApp.Models
{
    public class Channel
    {
        public Channel()
        {
            BloggerChannels = new List<BloggerChannel>();
            Videos = new List<Video>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Це поле не повинно бути порожнім")]
        [Display(Name = "Назва")]
        public string Title { get; set; }
        [Display(Name = "Опис")]
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<BloggerChannel> BloggerChannels { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
