using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArch.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string  Name { get;  set; }

        [Required(ErrorMessage ="The description is required")]
        [MinLength(5)]
        [MaxLength(100)]
        public string  Description { get;  set; }

        [Required(ErrorMessage ="The price is required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Price")]
        [MinLength(5)]
        [MaxLength(100)]
        public decimal Price { get;  set; }

        [Range(1,999)] //Valor minimum e value maximum
        [DisplayName("Stock")]
        public int  Stock { get;  set; }

        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string  Image { get;  set; }

        public int CategoryId { get; set; }
    }
}