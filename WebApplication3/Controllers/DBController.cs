using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.ViewModel;
using Type = WebApplication3.Models.Type;

namespace WebApplication3.Controllers
{
    public class DBController : Controller
    {
        private static List<Product> products = new List<Product>();
        private static List<Blog> blogs = new List<Blog>();
        private static List<Company> _company = new List<Company>();
        private static List<Type> _type = new List<Type>();

        private readonly ApplicationDbContext _db;
        public DBController(ApplicationDbContext db)
        {
            _company.Add(new Company { Id=1 , Name="Nike"});
            _company.Add(new Company { Id = 2, Name = "adidas" });
            _type.Add(new Type { Id = 1, Name = "Drama" });
            _type.Add(new Type { Id = 2, Name = "Comedy" });

            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            var co=_db.companies.ToList();
            var productView = new ProductViewModel()
            {
                companies = co
            };
            return View(productView);
        }
        
      
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
          

            if (!ModelState.IsValid)
            {
                ProductViewModel ss=new ProductViewModel();
                ss.product = product;

                ss.companies = _db.companies.ToList();


                return View(ss);
            }
          _db.products.Add(product);
            _db.SaveChanges();
          
            return RedirectToAction("GetAllData");
        }
        #region 
        public IActionResult GetAllData()
        {
            var products = _db.products.Include(p => p.comp).ToList();
            return View(products);

        }
        #endregion
        #region delete
        public IActionResult DeleteProduct(int id)
        {
            Product? pro = _db.products.FirstOrDefault(x => x.Id == id);
            _db.products.Remove(pro);
            _db.SaveChanges();
            return RedirectToAction("GetAllData");

        }
        #endregion
        #region editpro
        public IActionResult EditProduct(int id)
        {
            Product? pro = _db.products.FirstOrDefault(x => x.Id == id);
            _db.SaveChanges();

            return View(pro);

        }
        [HttpPost]
        public IActionResult EditProduct(Product pro)
        {
            Product? p= _db.products.FirstOrDefault(x => x.Id==pro.Id);
            p.Name= pro.Name;
            p.Description= pro.Description;
            p.Price= pro.Price;
            p.Quant= pro.Quant;
            p.EnableSize=pro.EnableSize;
            p.CompanyId = pro.CompanyId;
           _db.Update(p);
            _db.SaveChanges();
                
            return RedirectToAction("index");

        }
        #endregion
        public IActionResult AddBlog()
        {
            var ty = _db.types.ToList();
            var BlogView = new BlogViewModel()
            {
                types = ty
            };
            return View(BlogView);
        }
       [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                BlogViewModel b = new BlogViewModel();
                b.blog = blog;

                b.types = _db.types.ToList();


                return View(b);
            }

            _db.blogs.Add(blog);
            _db.SaveChanges();
            
            return RedirectToAction("ViewBlog");
        }
        #region 
        public IActionResult ViewBlog()
        {
            var blogs = _db.blogs.Include(p => p.type).ToList();

            return View(blogs);

        }
        #endregion
        #region delete2
        public IActionResult DeleteBlog(int id)
        {
            
           
            Blog? b = _db.blogs.FirstOrDefault(x => x.Id == id);
            _db.blogs.Remove(b);
            _db.SaveChanges();
            

            return RedirectToAction("ViewBlog");

        }
        #endregion
        #region editblog
        public IActionResult EditBlog(int id)
        {
            Blog? b = _db.blogs.FirstOrDefault(x => x.Id == id);
            _db.SaveChanges();

            return View(b);

        }
        [HttpPost]
        public IActionResult EditBlog(Blog bl)
        {
            Blog? b = _db.blogs.FirstOrDefault(x => x.Id == bl.Id);
           b.Title = bl.Title;
            b.Description = bl.Description;
            b.TypeId=bl.TypeId;
            _db.Update(b);
             _db.SaveChanges();
            return RedirectToAction("index");

        }
        #endregion

    }
}
