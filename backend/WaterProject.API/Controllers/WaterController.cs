using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterProject.API.Data;

namespace WaterProject.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WaterController : ControllerBase
    {
        private WaterDbContext _context;
        public WaterController(WaterDbContext temp) => _context = temp;

        [HttpGet("AllProjects")]
        public IActionResult GetProjects(int pageSize = 5, int pageNum = 1)
        {
            string? favProjType = Request.Cookies["FavoriteProjectType"];
            Console.WriteLine("~~~~~COOKIE~~~~\n" + favProjType);

            HttpContext.Response.Cookies.Append("FavoriteProjectType", "BoreHole Well and Hand Pump", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.Now.AddMinutes(1)
            });

            var something = _context.Projects
                .Skip((pageNum-1)*pageSize)
                .Take(pageSize)
                .ToList();
            
            var totalNumProjects = _context.Projects.Count();

            var someObject = new
            {
                Projects = something,
                totalNumProjects = totalNumProjects
            };

            return Ok(someObject);
        }

        [HttpGet("FunctionalProjects")]
        public IEnumerable<Project> GetFunctionalProjects()
        {
            var something = _context.Projects.Where(p => p.ProjectFunctionalityStatus == "Functional").ToList();
            return something;
        }
        
    }
}
