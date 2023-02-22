using System.ComponentModel.DataAnnotations;

namespace AllupTask.Models
{
    public class Brand:BaseEntity
    {
        [StringLength(255,ErrorMessage ="Putin:слава Украине,Forever Biden")]
        [Required(ErrorMessage ="Мы ждем тебя")]
        public string Name{ get; set; }
        public IEnumerable<Product>? Products{ get; set; }
    }
}
