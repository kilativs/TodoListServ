using System;
using TodoListServ.Models.Entities;

namespace TodoListServ.Models
{
    /// <summary>
    /// Класс модели для редактированния выбранной задачи
    /// </summary>
    public class EditListWorkModel
    {
        /// <summary>
        /// Id задачи
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название задачи
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Приоритет задачи
        /// </summary>
        public Priority PriorityWork { get; set; }
        /// <summary>
        /// Строк выполнения задачи
        /// </summary>
        public DateTime Deadline { get; set; }
        /// <summary>
        /// Состояние задачи
        /// </summary>
        public Condition ConditionWork { get; set; }
    }
}