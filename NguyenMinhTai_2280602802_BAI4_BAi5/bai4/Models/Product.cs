using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace bai4.Models
{
    public class Product
    {
        //Khai báo các thuộc tính
        public int Id { get; set; }
        //yêu cầu bắt buộc thì phải có chữ required
        //String length chiều dài tối đa
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        //Khóa ngoại
        public List<ProductImage>? Images { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
