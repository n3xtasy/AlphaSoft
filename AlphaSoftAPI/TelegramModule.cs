using AlphaSoftAPI.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AlphaSoftAPI
{
    public class TelegramModule
    {
        private static TelegramBotClient TelegramBotClient { get; set; }
        public static void Initialize()
        {
            TelegramBotClient = new TelegramBotClient("1996247578:AAEj1lGbOslNAoHUg0MPGJML4rMnzq4CQQw");
        }
        public static async Task<List<Message>> SendMessageAsync(Order order)
        {
            long[] chatIds = new long[]
                {
                    782549526, 1682680708
                };

            List<Message> messages = new List<Message>();

            foreach (var id in chatIds)
            {
                messages.Add(await TelegramBotClient.SendTextMessageAsync(
                  chatId: id,
                  text: $"Новый заказ: {order.Id}\n\n" +
                        $"Имя: {order.Buyer.FirstName}\n" +
                        $"Фамилия: {order.Buyer.LastName}\n" +
                        $"Телефон: {order.Buyer.Phone}\n" +
                        $"Действие: Поступил запрос на отправку ключа\n\n" +
                        $"Статус: {order.Status}\n" +
                        $"Комментарий: {(string.IsNullOrEmpty(order.Notes) ? "Комментарий отсутствует" : $"{order.Notes}")}\n"
                        )
                );
            }

            return messages;
        }

        public static async void EditMessageAsync(List<Message> messages, Order order, string move, string code)
        {
            foreach (var message in messages)
            {
                await TelegramBotClient.EditMessageTextAsync(
                    chatId: message.Chat.Id,
                    messageId: message.MessageId,
                    text: $"Новый заказ: {order.Id}\n\n" +
                        $"Имя: {order.Buyer.FirstName}\n" +
                        $"Фамилия: {order.Buyer.LastName}\n" +
                        $"Телефон: {order.Buyer.Phone}\n" +
                        $"Действие: {move}\n\n" +
                        $"Ключ: {code}\n" +
                        $"Статус: {order.Status}\n" +
                        $"Комментарий: {(string.IsNullOrEmpty(order.Notes) ? "Комментарий отсутствует" : $"{order.Notes}")}\n"
                    );
            }
        }
    }
}
