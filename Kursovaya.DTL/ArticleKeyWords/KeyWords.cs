using Kursovaya.DTL.Users.Telegram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.DTL.ArticleKeyWords
{
    public class KeyWords
    {
        public int Id { get;set; }
        public string KeyWord { get; set; }
        public List<BotUser> Users { get; set; }
    }
}
