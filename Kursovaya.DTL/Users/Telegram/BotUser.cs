using Kursovaya.DTL.ArticleKeyWords;
using Kursovaya.DTL.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.DTL.Users.Telegram
{
    public class BotUser
    {
        public int Id { get; set; } 
        public long TId { get; set; }
        public string Name { get; set; } 
        public MachineState Status { get; set; }
        public DateTime FirstDate { get; set; }   
        public int NotificationHour { get; set; } 
        public bool Banned { get;set; }
        public List<KeyWords> KeyWords { get; set; }
    }

}
