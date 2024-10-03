using ASPWebApplication.Models;
using ASPWebApplication.Models.ViewModels;
using ASPWebApplication.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;

namespace ASPWebApplication.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;


		public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}
		public IActionResult Index()
		{
			List<Product> products = _unitOfWork.Product.GetAll().ToList();
			
			return View(products);
		}

		public IActionResult Upsert(int? id) {
			ProductVM productVM = new()
			{
				Categories = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				}),
				Product = new Product()

			};
			if(id == null || id == 0)
			{
				//create new product
				return View(productVM);
			} else
			{
				//update
				productVM.Product = _unitOfWork.Product.Get(u=>u.Id == id);
				return View(productVM);

			}
		}

		[HttpPost]
		public IActionResult Upsert(ProductVM productVM, IFormFile? file)
		{
			
			if (ModelState.IsValid) {
				
					string rootPath = _webHostEnvironment.WebRootPath;
					if(file != null)
					{
						string fileName = Guid.NewGuid().ToString()+ Path.GetExtension(file.FileName);
						string productPath = Path.Combine(rootPath, @"images\product");

					if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
					{
						//delete old image
						var oldPath = 
							Path.Combine(rootPath, productVM.Product.ImageUrl.TrimStart('\\'));
						if (System.IO.File.Exists(oldPath)) { 
							System.IO.File.Delete(oldPath);
						}
					}
						using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
						{
							file.CopyTo(fileStream);
						}
						productVM.Product.ImageUrl = @"\images\product\" + fileName;

					}
				if (productVM.Product.Id == 0)
				{
					_unitOfWork.Product.Add(productVM.Product);
					
					TempData["success"] = "Product created successfully.";
				}
				else
				{
					_unitOfWork.Product.Update(productVM.Product);
					TempData["success"] = "Product updated successfully.";
				}
				_unitOfWork.Save();


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
