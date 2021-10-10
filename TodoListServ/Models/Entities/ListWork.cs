using System;

namespace TodoListServ.Models.Entities
{
    /// <summary>
    /// Клас определения списка задач
    /// </summary>
    public class ListWork
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
        /// Строк віполнения задачи
        /// </summary>
        public DateTime Deadline { get; set; }
        /// <summary>
        /// Состояние задачи
        /// </summary>
        public Condition ConditionWork { get; set; }
    }
}