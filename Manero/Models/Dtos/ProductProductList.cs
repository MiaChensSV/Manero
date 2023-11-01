﻿namespace Manero.Models.Dtos
{
    public class ProductProductList
    {

        public string? ArticleNumber { get; set; } = null!;
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? VendorName { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }
        public string? AverageReviewRating { get; set; }
        public List<string> ProductWishList { get; set; } = new List<string>();

    }
}
