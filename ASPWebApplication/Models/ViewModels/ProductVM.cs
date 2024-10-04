﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPWebApplication.Models.ViewModels
{
	public class ProductVM
	{
		public Product Product { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> Categories { get; set; }
	}
}
