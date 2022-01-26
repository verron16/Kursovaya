using Kursovaya.DAL.DataBase;
using Kursovaya.Core.Exceptions;
using Kursovaya.Core.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Kursovaya
{
    public class Program
    {
        private static TelegramBotClient client = new TelegramBotClient("кудааа мы лееезем, кудааа?");
        private static ReceiverOptions receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { }
        };

        static async Task Main(string[] args)
        {
            try
            {
                #region BotConnecting
                client.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions);
                var me = await client.GetMeAsync();
                await client.DeleteWebhookAsync();
                Console.WriteLine($"Start listening for @{me.Username}");
                #endregion

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                IReadOnlyList<BLL.Commands.GeneralCommand> comands = BLL.Command.Command.GetCommands();
                var Data = GetInformationFromUpdate(update);
                long TId = Data.Item2;
                string Text = Data.Item1;
                if (BLL.Users.TelegramUser.IsBanned(TId))
                {
                    await client.SendTextMessageAsync(TId, "Вы забанены!");
                    return;
                }
                var user = BLL.Users.TelegramUser.Get(TId);
                foreach (var com in comands)
                {
                    if (com.Contains(Text))
                    {
                        await com.ExecuteAsync(update, client, user);
                        return;
                    }
                }

                #region StateMachine
                BLL.StateMachine.StateMachine.Execute(user, update, client, Text);
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Logger.Error(exception);
            return Task.CompletedTask;
        }
        public static (string, long) GetInformationFromUpdate(Update update)
        {
            Message message;
            string Text = "";
            long TId = 0;
            try
            {
                if (update.CallbackQuery?.Data != null || update.Message?.Text != null)
                {
                    Text = update.CallbackQuery == null ? update.Message.Text : update.CallbackQuery.Data;
                }

                if (update.CallbackQuery != null)
                {
                    TId = update.CallbackQuery.From.Id;
                }
                else if (update.Message != null)
                {
                    message = update.Message;
                    TId = message.From.Id;
                }
                return (Text, TId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ("", 0);
            }
        }
    }
}
