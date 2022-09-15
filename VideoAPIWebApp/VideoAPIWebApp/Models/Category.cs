using System.ComponentModel.DataAnnotations;

namespace VideoAPIWebApp.Models
{
    public class Category
    {
        public Category()
        {
            Channels = new List<Channel>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Це поле не повинно бути порожнім")]
        [Display(Name = "Категорія каналів")]
        public string Name { get; set; }
        [Display(Name = "Опис")]
        public string Description { get; set; }

        public virtual ICollection<Channel> Channels { get; set; }
    }
}
