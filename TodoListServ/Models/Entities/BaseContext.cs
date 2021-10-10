using System;
using Microsoft.EntityFrameworkCore;

namespace TodoListServ.Models.Entities
{
    /// <summary>
    /// Класс для работы службы с БД
    /// </summary>
    public sealed class BaseContext : DbContext
    {
        /// <summary>
        /// Коллекция сущностей БД списка дел
        /// </summary>
        public DbSet<ListWork> ListWorks { get; set; }

        /// <summary>
        /// Возможность службы создавать таблицы в БД
        /// </summary>
        public BaseContext()
        {
            Database.EnsureCreated();
        }
        /// <summary>
        /// Подключение к БД
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=;database=list",
                new MySqlServerVersion(new Version(8, 0, 0)));
        }
    }
}