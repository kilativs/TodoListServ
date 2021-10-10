using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using TodoListServ.Models;
using TodoListServ.Models.Entities;

namespace TodoListServ.Controllers
{
    /// <summary>
    /// Класс взаемодействия службы с БД
    /// </summary>
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class ListWorkController : ControllerBase
    {
        private readonly BaseContext _db;

        /// <summary>
        /// Подключение к БД
        /// </summary>
        /// <param name="db"></param>
        public ListWorkController(BaseContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Вывод всего списка задач из БД
        /// </summary>
        /// <returns>вывод списка задач</returns>
        [HttpGet]
        public IActionResult GetAllListWork()
        {
            var listWork = _db.ListWorks.Where(n => n.Id > 0).ToList();
            return new JsonResult(listWork);
        }

        /// <summary>
        /// Вывод задачи с БД по ее id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>вывод конкретной задачи</returns>
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("getById")]
        public IActionResult GetList(int id)
        {
            var list = _db.ListWorks.FirstOrDefault(n => n.Id == id);
            if (list is null) return BadRequest(new {errorText = "Invalid list Id"});
            return new JsonResult(list);
        }

        /// <summary>
        /// Создание новой задачи
        /// </summary>
        /// <param name="model"></param>
        /// <returns>результаа сохранения в БД</returns>
        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("create")]
        public IActionResult CreateListWork([FromBody] CreateListWorkModel model)
        {
            var newList = new ListWork
            {
                Title = model.Title,
                Description = model.Description,
                PriorityWork = model.PriorityWork,
                Deadline = model.Deadline,
                ConditionWork = model.ConditionWork
            };
            _db.ListWorks.Add(newList);
            _db.SaveChanges();
            return Ok("Saved");
        }

        /// <summary>
        /// Редактирование выбраной задачи по ее id
        /// </summary>
        /// <param name="model"></param>
        /// <returns>результаа сохранения в БД</returns>
        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("edit")]
        public IActionResult EditListWork([FromBody] EditListWorkModel model)
        {
            var list = _db.ListWorks.FirstOrDefault(n => n.Id == model.Id);
            if (list is null) return BadRequest("Invalid list id");

            list.Title = model.Title;
            list.Description = model.Description;
            list.PriorityWork = model.PriorityWork;
            list.Deadline = model.Deadline;
            list.ConditionWork = model.ConditionWork;

            _db.SaveChanges();
            return Ok("Saved");
        }

        /// <summary>
        /// Удаление выбранной задачи по ее id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>результаа сохранения в БД</returns>
        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("remove")]
        public IActionResult RemoveListWork(int id)
        {
            var list = _db.ListWorks.FirstOrDefault(n => n.Id == id);
            if (list is null) return BadRequest("Invalid list id");

            _db.ListWorks.Remove(list);
            _db.SaveChanges();
            return Ok("Remove");
        }
    }
}