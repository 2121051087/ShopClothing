﻿using ShopClothing.Models;
using System.ComponentModel.DataAnnotations;

namespace ShopClothing.Data
{

    public class ProductDetailDTO
    {
        
        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public double Price { get; set; }
        public int CategoryID { get; set; }

        //public List<ColorSidesDTO> colorSizesDTO { get; set; } = new List<ColorSidesDTO>();

       // public IFormFile ImageProduct { get; set; }

        public string colorSizesDTO { get; set; }



    }

   
    public class ColorSidesDTO 
    {
    
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        public int Quantity { get; set; }
    }




}
