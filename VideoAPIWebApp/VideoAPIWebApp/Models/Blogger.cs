using System.ComponentModel.DataAnnotations;

namespace VideoAPIWebApp.Models
{
    public class Blogger
    {
        public Blogger()
        {
            BloggerChannels = new List<BloggerChannel>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Це поле не повинно бути порожнім")]
        [Display(Name = "Нікнейм")]
        public string Name { get; set; }
        [Display(Name = "Опис")]
        public string? Description { get; set; }
        public virtual ICollection<BloggerChannel> BloggerChannels { get; set; }
    }
}
