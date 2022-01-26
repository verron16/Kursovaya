using Kursovaya.DTL.StateMachine;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Kursovaya.BLL.StateMachine
{
    public static class StateMachine
    {
        public static async void Execute(DTL.Users.Telegram.BotUser user, Update message, TelegramBotClient client, string text)
        {
            if (user == null)
            {
                return;
            }
            switch (user.Status)
            {
                case MachineState.None:
                    {
                        return;
                    }
                case MachineState.ChangeNotificationHour:
                    {
                        int newHour;
                        if (!int.TryParse(text, out newHour) || newHour < 0 || newHour > 23)
                        {
                            await client.SendTextMessageAsync(user.TId, "Введите число от 0 до 23");
                            return;
                        }
                        BLL.Users.TelegramUser.ChangeNotificationHour(user, 1);
                        BLL.Users.TelegramUser.SetStatus(user, MachineState.None);
                    }
                    break;
                case MachineState.SetKeyWords:
                    {
                        List<string> keyWords = text.Split(',').ToList();
                        if (keyWords.Count < 0)
                        {
                            return;
                        }
                        var userKeyWords = BLL.Users.TelegramUser.GetKeyWords(user);
                        if (userKeyWords.Count > Core.Global.KeyWordsPerUser)
                        {
                            await client.SendTextMessageAsync(user.TId, $"Превышен лимит в {Core.Global.KeyWordsPerUser} ключевых слов");
                            return;
                        }
                        var existsKeyWords = BLL.ArticleKeyWords.KeyWords.GetExistingKeyWords(keyWords);
                        BLL.Users.TelegramUser.SetKeyWords(user, existsKeyWords.Take(Core.Global.KeyWordsPerUser - userKeyWords.Count).ToList());
                        BLL.Users.TelegramUser.SetStatus(user, MachineState.None);
                        await client.SendTextMessageAsync(user.TId, "Ключевые слова были успешно установлены");

                    }
                    break;
            }
        }
    }
}
