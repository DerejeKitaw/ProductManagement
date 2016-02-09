
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APM.WebAPI.Models
    {
    public class Product
        {
        public string Description { get; set; }
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product Code is Required", AllowEmptyStrings = false)]
        [MinLength(5, ErrorMessage = "ProductCode min length is 6 Characters")]
        public string ProductCode { get; set; }

        public int ProductId { get; set; }
        [Required(ErrorMessage ="Product Name is Required",AllowEmptyStrings =false)]
        [MinLength(5,ErrorMessage ="Product name min length is 5 Characters")]
        [MaxLength(11, ErrorMessage = "Product name max length is 11 Characters")]
        public string ProductName { get; set; }
        public DateTime ReleaseDate { get; set; }

        }
    }