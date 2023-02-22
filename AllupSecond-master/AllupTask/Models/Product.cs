using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllupTask.Models
{
    public class Product:BaseEntity
    {
        [StringLength(1000)]
        public string Title{ get; set; }
        [Column(TypeName ="money")]
        public double Price{ get; set; }
        [Column(TypeName = "money")]
        public double DiscountPrice{ get; set; }
        [Column(TypeName = "money")]
        public double ExTax{ get; set; }
        [StringLength(4)]
        public string Seria{ get; set; }
        public int Code{ get; set; }
        [StringLength(255)]
        public bool IsNewArrival { get; set; }
        public bool IsBestseller{ get; set; }
        public bool IsFeatured { get; set; }
        public string BasicInfo{ get; set; }
        [StringLength(1000)]
        public string Description{ get; set; }
        [StringLength(255)]
        public string MainImage{ get; set; }
        [StringLength(255)] 
        public string HoverImage{ get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public IEnumerable< ProductTag> ProductTags { get; set; }

        //public IEnumerable<ProductImage>ProductImages { get; set; }

        public IEnumerable<ProductImage>ProductImages { get; set; }
    }
}
