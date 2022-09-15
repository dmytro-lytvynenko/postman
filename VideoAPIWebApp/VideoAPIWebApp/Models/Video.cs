using System.ComponentModel.DataAnnotations;

namespace VideoAPIWebApp.Models
{
    public class Video
    {
        public Video()
        {
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Це поле не повинно бути порожнім")]
        [Display(Name = "Назва")]
        public string Title { get; set; }
        [Display(Name = "Опис")]
        public string? Description { get; set; }
        public int ChannelId { get; set; }
        public virtual Channel Channel { get; set; }
    }
}