using ASP.NET_Practice_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Practice_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private static List<Homework> homeworks = new List<Homework>();

        private static long idGenerator = 1L;

        [HttpGet]
        public async Task<ActionResult<List<Homework>>> GetHomeworks()
        {
            return Ok(homeworks);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Homework>> GetHomeworkById(long id)
        {
            Homework homework = homeworks.Find(h => h.Id == id);
            if (homework == null)
            {
                return NotFound();
            }
            return Ok(homework);
        }

        [HttpPost]
        public async Task<ActionResult<List<Homework>>> AddHomework(Homework homework)
        {
            homework.Id = idGenerator++;
            homeworks.Add(homework);
            return Ok(homeworks);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<Homework>>> EditHomeworkById(long id , Homework homework)
        {
            foreach (Homework h in homeworks)
            {
                if (h.Id == id) { 
                    h.Title = homework.Title;
                    h.Description = homework.Description;
                    h.Subject = homework.Subject;
                    h.Score= homework.Score;
                }
            }
            return Ok(homeworks);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Homework>>> DeleteHomeworkById(long id)
        {
            Homework homework = homeworks.Find(h => h.Id == id);
            if (homework == null)
            {
                return NotFound();
            }

            homeworks.Remove(homework);
            return Ok(homeworks);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Homework>>> DeleteHomeworks()
        {
            homeworks.Clear();
            idGenerator = 1L;
            return Ok(homeworks);
        }
    }
}
