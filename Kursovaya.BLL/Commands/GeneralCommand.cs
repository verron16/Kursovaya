using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Kursovaya.BLL.Commands
{
    public abstract class GeneralCommand
    {
        public abstract string Name { get; }

        public abstract Task ExecuteAsync(Update message, TelegramBotClient client, DTL.Users.Telegram.BotUser user = null);

        public bool Contains(string message)
        {
            return message.ToLower().Contains(Name.ToLower());
        }
    }
}
