namespace Manero.ViewModels;

public class CheckOutViewModel
{
	public string? UserId { get; set; }
	public class CheckOutViewModel
	{
		public string? UserId { get; set; }

		public string? ArticleNumber { get; set; }
		public string? ProductName { get; set; }
		public decimal Price { get; set; }
		public string? Image { get; set; }
		public string? Size { get; set; }
		public string? Color { get; set; }
		public decimal Subtotal { get; set; }
		public decimal Total { get; set; }
		public decimal Discount { get; set; }
		public List<OrderDetailEntity> OrderDetails { get; set; } = new List<OrderDetailEntity>();
		public string? ShippingAddress { get; set; }
		public string? PaymentMethod { get; set; }
		public string? Comment { get; set; }
		public decimal DeliveryFee { get; set; }
		public string? ArticleNumber { get; set; }
		public string? ProductName { get; set; }
		public decimal Price { get; set; }
		public string? Image { get; set; }
		public string? Size { get; set; }
		public string? Color { get; set; }
		public decimal Subtotal { get; set; }
		public decimal Total { get; set; }
		public decimal Discount { get; set; }
		public List<OrderDetailEntity> OrderDetails { get; set; } = new List<OrderDetailEntity>();
		public string? ShippingAddress { get; set; }
		public string? PaymentMethod { get; set; }
		public string? Comment { get; set; }
		public decimal DeliveryFee { get; set; }


		public static implicit operator OrderEntity(CheckOutViewModel viewmodel)
		{
			var entity = new OrderEntity()
			{
				UserId = viewmodel.UserId,
				StatusId = 2,
				PromocodeId = 1,
				ShippingAddress = viewmodel.ShippingAddress,
				OrderDetailItems = viewmodel.OrderDetails,
				DeliveryFee = viewmodel.DeliveryFee,
				TotalCost = viewmodel.Total,

			};
			return entity;
		}
		public static implicit operator OrderEntity(CheckOutViewModel viewmodel)
		{
			var entity = new OrderEntity()
			{
				UserId = viewmodel.UserId,
				StatusId = 2,
				PromocodeId = 1,
				ShippingAddress = viewmodel.ShippingAddress,
				ShippingAddress = viewmodel.ShippingAddress ?? "Hej",
				OrderDetailItems = viewmodel.OrderDetails,
				DeliveryFee = viewmodel.DeliveryFee,
				TotalCost = viewmodel.Total,

			};
			return entity;
		}

	}
