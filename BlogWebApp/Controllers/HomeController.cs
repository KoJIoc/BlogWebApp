using ClassLibrary.Data.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogWebApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        private readonly UserManager<ArticleUser> _userManager;
        public HomeController(UserManager<ArticleUser> userManager,  ApplicationContext context)
        {
            _userManager = userManager;
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            string id = _userManager.GetUserId(HttpContext.User);
            return View(db.Articles.Where(p => p.UserID == id));
        }
        public IActionResult CreateArticle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            article.DateOfCreation = DateTime.Now;
            article.UserID = _userManager.GetUserId(HttpContext.User);
            db.Articles.Add(article);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Article article = await db.Articles.FirstOrDefaultAsync(p => p.Id == id);
                if (article != null)
                    return View(article);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Article article = await db.Articles.FirstOrDefaultAsync(p => p.Id == id);

                if (article != null)
                    return View(article);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Article article)
        {
            article.UserID = _userManager.GetUserId(HttpContext.User);
            article.DateOfCreation = DateTime.Now;
            db.Articles.Update(article);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Article article = await db.Articles.FirstOrDefaultAsync(p => p.Id == id);
                if (article != null)
                    return View(article);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Article article = await db.Articles.FirstOrDefaultAsync(p => p.Id == id);
                if (article != null)
                {
                    db.Articles.Remove(article);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }


        public IActionResult CreateTag()
        {
            string id = _userManager.GetUserId(HttpContext.User);
            ViewData["ArticleID"] = new SelectList(db.Articles.Where(p => p.UserID == id), "Id", "Title");
            ViewData["TagID"] = new SelectList(db.Tags, "Id", "Title");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTag(int? articleid, [Bind("articleID,tagID")] ArticleTag articleTag)
        {

            if (ModelState.IsValid)
            {
                db.Add(articleTag);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult SearchArticl()
        {
            ViewData["TagID"] = new SelectList(db.Tags, "Id", "Title");
            return View();
        }
        [HttpPost]
        public IActionResult SearchArticle(int? TagId)
        {
            return View(db.ArticleTags.Include(p => p.article).Where(s => s.tagID == TagId).Select(p=>p.article).ToList());
        }

        public IActionResult CreateComment()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> CreateComment(Comment comment)
        {
            comment.Date = DateTime.Now;
            comment.UserID = _userManager.GetUserId(HttpContext.User);
            comment.UserLogin = User.Identity.Name;
            db.Comments.Add(comment);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult SeeComment()
        {
            return View(db.Comments);
        }


    }
}
