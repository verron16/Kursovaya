using Kursovaya.DTL.Users.Telegram;
using Kursovaya.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Kursovaya.BLL.Commands
{
    public class HelloCommand : GeneralCommand
    {
        public override string Name => "/start";

        public override async Task ExecuteAsync(Update message, TelegramBotClient client, DTL.Users.Telegram.BotUser user)
        {
            long tid = message.Message.From.Id;

            user = BLL.Users.TelegramUser.Get(tid);
            if (user == null)
            {
                BLL.Users.TelegramUser.Add(new BotUser()
                {
                    FirstDate = DateTime.Now,
                    TId = tid,
                    Name = message.Message.From.Username,
                    NotificationHour = -1,
                    Status = DTL.StateMachine.MachineState.None
                });
            }

            BLL.Users.TelegramUser.SetStatus(user, DTL.StateMachine.MachineState.SetKeyWords);
            await client.SendTextMessageAsync(user.TId, "Введите ключевые слова для поиска. Если есть слова на выбор - разделяйте запятыми.");
        }
    }
}
