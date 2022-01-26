using Kursovaya.DAL.Users;
using Kursovaya.DTL.StateMachine;
using Kursovaya.Core.Data;
using Kursovaya.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.BLL.Users
{
    public static class TelegramUser
    {
        public static bool IsBanned(long tid)
        {
            var dm = DataManager.GetDataManager<IUserDataManager>();
            return dm.IsUserBanned(tid);
        }

        public static void Add(DTL.Users.Telegram.BotUser user)
        {
            var dm = DataManager.GetDataManager<IUserDataManager>();
            dm.AddUser(user);
        }

        public static DTL.Users.Telegram.BotUser Get(long tid)
        {
            var dm = DataManager.GetDataManager<IUserDataManager>();
            return dm.GetUser(tid) ?? throw new UserIsNullException(tid);
        }

        public static void SetStatus(DTL.Users.Telegram.BotUser user, MachineState status)
        {
            var dm = DataManager.GetDataManager<IUserDataManager>();
            dm.SetStatus(user, status);
        }

        public static void ChangeNotificationHour(DTL.Users.Telegram.BotUser user, int hour)
        {
            var dm = DataManager.GetDataManager<IUserDataManager>();
            dm.SetNotificationHour(user, hour);
        }

        public static void SetKeyWords(DTL.Users.Telegram.BotUser user, List<DTL.ArticleKeyWords.KeyWords> keyWords)
        {
            var dm = DataManager.GetDataManager<IUserDataManager>();
            dm.SetKeyWords(user, keyWords);
        }

        public static List<DTL.ArticleKeyWords.KeyWords> GetKeyWords(DTL.Users.Telegram.BotUser user)
        {
            var dm = DataManager.GetDataManager<IUserDataManager>();
            return dm.GetKeyWords(user);
        }
    }
}
