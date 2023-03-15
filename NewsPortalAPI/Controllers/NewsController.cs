using Microsoft.AspNetCore.Mvc;
using NewsPortalAPI.Data;
using NewsPortalAPI.Models;

namespace NewsPortalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetNews")]
        public IActionResult GetNews()
        {
            IEnumerable<News> news = _context.News;
            return Ok(news);
        }
        [HttpGet("GetNewsById")]
        public IActionResult GetNewsById(int id)
        {
            News news = _context.News.Where(n => n.id == id).FirstOrDefault();

            return Ok(news);
        }

        [HttpPost("Create")]
        public IActionResult Create(News newsobj)
        {        
                _context.News.Add(newsobj);
                _context.SaveChanges();
                return Ok("Record Added Successfully !");
        }
        [HttpPost("Edit")]
        public IActionResult Edit(News newsobj)
        {
            _context.News.Update(newsobj);
            _context.SaveChanges();
            return Ok("Updated Successfully !");
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var deleterecord = _context.News.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.News.Remove(deleterecord);
            _context.SaveChanges();
            return Ok("Deleted Successfully !");
        }


    }
}
