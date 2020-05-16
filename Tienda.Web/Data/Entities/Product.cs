
using System;
using System.ComponentModel.DataAnnotations;

namespace Tienda.Web.Data.Entities
{
    

    public class Product
    {
		public int Id { get; set; }

		[MaxLength(50, ErrorMessage = "El campo {0} solo puede tener un máximo {1} Caracteres")]
		[Required]

		public string Name { get; set; }

		[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
		public decimal Price { get; set; }

		[Display(Name = "Image")]
		public string ImageUrl { get; set; }

		[Display(Name = "Last Purchase")]
		public DateTime? LastPurchase { get; set; }

		[Display(Name = "Last Sale")]
		public DateTime? LastSale { get; set; }

		[Display(Name = "Is Availabe?")]
		public bool IsAvailabe { get; set; }

		[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
		public double Stock { get; set; }

	}
}
