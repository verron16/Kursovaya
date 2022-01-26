using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Kursovaya.DAL.DataBase
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection") { }
        public DbSet<DTL.Users.Telegram.BotUser> Users { get; set; }
        public DbSet<DTL.ArticleKeyWords.KeyWords> KeyWords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.Log = (query) => Console.Write(query);
        }
    }
}
