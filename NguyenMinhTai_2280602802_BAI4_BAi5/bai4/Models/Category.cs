using System.ComponentModel.DataAnnotations;
using bai4.Models;
using Microsoft.AspNetCore.Mvc;

namespace bai4.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Url { get; set; }

        //Khóa ngoại
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
