using ASPWebApplication.Models;
using ASPWebApplication.Models.ViewModels;
using ASPWebApplication.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ASPWebApplication.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			List<Product> products = _unitOfWork.Product.GetAll().ToList();
			
			return View(products);
		}

		public IActionResult Create() {
			ProductVM productVM = new()
			{
				Categories = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				}),
				Product = new Product()

			};
			return View(productVM);
		}

		[HttpPost]
		public IActionResult Create(ProductVM productVM)
		{
			if (ModelState.IsValid) {
				_unitOfWork.Product.Add(productVM.Product);
				_unitOfWork.Save();
				TempData["success"] = "Product created successfully.";
				return RedirectToAction("Index");
			} else
			{
				productVM.Categories = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				});
				return View(productVM);
			}
			
		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Product productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
			if (productFromDb == null)
			{
				return NotFound();
			}

			return View(productFromDb);
		}

		[HttpPost]
		public IActionResult Edit(Product product) {

			if (ModelState.IsValid && product != null) 
			{
				_unitOfWork.Product.Update(product);
				_unitOfWork.Save();
				TempData["success"] = "Product updated successfully.";
				return RedirectToAction("Index");
			}
			TempData["error"] = "Product could not be updated.";

			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Product product = _unitOfWork.Product.Get(u => u.Id == id);
			if (product == null)
			{
				return NotFound();

			}
			return View(product);
		}

		[HttpPost, ActionName("Delete")]

		public IActionResult DeletePOST(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Product product = _unitOfWork.Product.Get(u => u.Id == id);
			if (product == null)
			{
				return NotFound();

			}
			_unitOfWork.Product.Remove(product);
			_unitOfWork.Save();
			TempData["success"] = "Product deleted successfully.";
			return RedirectToAction("Index");
		}

	}
}
