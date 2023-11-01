﻿namespace Manero.Models.Dtos
{
    public class WishListItem
    {
        public string? ArticleNumber { get; set; } = null!;
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? VendorName { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }
        public string? AverageReviewRating { get; set; }
    }
}
