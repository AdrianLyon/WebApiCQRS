using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSPractice.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}