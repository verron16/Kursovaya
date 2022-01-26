using Kursovaya.DTL.ArticleKeyWords;
using Kursovaya.DTL.StateMachine;
using Kursovaya.DTL.Users.Telegram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.DAL.Users
{
    public sealed class UserDataManager : IUserDataManager
    {
        public void AddUser(BotUser user)
        {
            using(DAL.DataBase.Context db = new DAL.DataBase.Context())
            {
                if(user != null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
        }

        public void BanUser(long tid)
        {
            using (DAL.DataBase.Context db = new DAL.DataBase.Context())
            {
                var user = GetUser(tid);
                if(user !=null)
                {
                    db.Users.Attach(user);
                    user.Banned = true;
                    db.SaveChangesAsync();  
                }
            }
        }

        public List<KeyWords> GetKeyWords(BotUser user)
        {
            using (DAL.DataBase.Context db = new DAL.DataBase.Context())
            {
                db.Users.Attach(user);
                return db.Users.Include("KeyWords").Where(i => i.TId == user.TId).FirstOrDefault().KeyWords;
            }
        }

        public BotUser GetUser(long tid)
        {
            using (DAL.DataBase.Context db = new DAL.DataBase.Context())
            {
                return db.Users.Where(i=>i.TId == tid).FirstOrDefault();
            }
        }

        public bool IsUserBanned(long tid)
        {
            using (DAL.DataBase.Context db = new DAL.DataBase.Context())
            {
                var user = GetUser(tid);
                if (user != null)
                {
                    return user.Banned;
                }
                return false;
            }
        }

        public void SetKeyWords(BotUser user, List<KeyWords> keyWords)
        {
            using (DAL.DataBase.Context db = new DAL.DataBase.Context())
            {
                db.Users.Attach(user);
                user.KeyWords = keyWords;
                db.SaveChanges();
            }
        }

        public void SetNotificationHour(BotUser user, int hour)
        {
            using (DAL.DataBase.Context db = new DAL.DataBase.Context())
            {
                db.Users.Attach(user);
                user.NotificationHour = hour;
                db.SaveChanges();
            }
        }

        public void SetStatus(BotUser user, MachineState status)
        {
            using (DAL.DataBase.Context db = new DAL.DataBase.Context())
            {
                db.Users.Attach(user);
                user.Status = status;
                db.SaveChanges();
            }
        }
    }
    
}
