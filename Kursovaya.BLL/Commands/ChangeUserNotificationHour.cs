using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Kursovaya.BLL.Commands
{
    public class ChangeUserNotificationHour : GeneralCommand
    {
        public override string Name => "ChangeHour";

        public override async Task ExecuteAsync(Update message, TelegramBotClient client, DTL.Users.Telegram.BotUser user)
        {
            await client.AnswerCallbackQueryAsync(message.CallbackQuery.Id);
            BLL.Users.TelegramUser.SetStatus(user, DTL.StateMachine.MachineState.ChangeNotificationHour);
            await client.SendTextMessageAsync(user.TId, "Напишите час, в который каждый день отправлять вам новые новости");
        }
    }
}
