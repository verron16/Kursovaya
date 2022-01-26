using Kursovaya.DTL.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.DAL.Users
{
    public interface IUserDataManager
    {
        bool IsUserBanned(long tid);
        void AddUser(DTL.Users.Telegram.BotUser user);  
        void BanUser(long tid);
        DTL.Users.Telegram.BotUser GetUser(long tid);
        void SetNotificationHour(DTL.Users.Telegram.BotUser user, int hour);
        void SetStatus(DTL.Users.Telegram.BotUser user, MachineState status);
        void SetKeyWords(DTL.Users.Telegram.BotUser user, List<DTL.ArticleKeyWords.KeyWords> keyWords);
        List<DTL.ArticleKeyWords.KeyWords> GetKeyWords(DTL.Users.Telegram.BotUser user);
    }
}
