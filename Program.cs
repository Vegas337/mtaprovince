using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using static MTAProvince.Information;
using static MTAProvince.HelloButton;
using static MTAProvince.WriteRead;
using System.Timers;

namespace MTAProvince
{
    internal class Program
    {
        private static string Token { get; set; } = "5125301015:AAEDca6aRwnybeNhSM39nrjQRxtAfg0KMJg";
        private static TelegramBotClient client;
        public static string ErrorAdmin = "⛔️ Данная команда доступна только администратору.";
        public static string Admin = "Vegas337";

        [Obsolete]
        static void Main(string[] args)
        {

            client = new TelegramBotClient(Token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }
        [Obsolete]
        static async void SendText (long chatId_, string text_, string replyMarkup_)
        {
                await client.SendTextMessageAsync(
                chatId: chatId_,
                text: text_,
                replyMarkup: GetButtons(replyMarkup_));
        }

       
        private static string IfTrueUser (string UserName)
        {
            if (UserName == "Vegas337")
            {
                return "true";
            }
            else if (UserName == "BLACK_KANEKIF")
            {
                return "true";
            }
            return "false";
        }


        [Obsolete]
        private static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (IfTrueUser(msg.Chat.Username) == "false") { SendText(msg.Chat.Id, "⛔️ У Вас нет доступа к этому чату.", "Начало"); return; }


                if (msg.Text != null)
            {
                Console.WriteLine($"{msg.Chat.Username}: {msg.Text}");
                string[] wordsMsgText = msg.Text.Split(' ');
                string[] wordsLvlText = msg.Text.Split(' ', '(',')','?','/','[',']');
                if (wordsMsgText.Length == 4)
                {
                    Numbers(wordsMsgText[0], wordsMsgText[1], int.Parse(wordsMsgText[2]), msg.Chat.Username);
                    SendText(msg.Chat.Id, $"{Info}", "Маршруты");
                } else { 
                    if (wordsLvlText.Length == 3) {
                        if (wordsLvlText[0] == "Уровень" | wordsLvlText[2] == "!") { 
                            if (int.Parse(wordsLvlText[1]) >= 4)
                            {
                                {
                                    int levelChet = WhatLevel(msg.Chat.Username, int.Parse(wordsMsgText[1]));
                                    if (levelChet == 202)
                                    {
                                        SendText(msg.Chat.Id, "Ошибка. Система не обнаружила Вас в базе данных. Обратитесь к администратору для получения доступа к этой команде.", "Начало");
                                    }
                                    else
                                    {
                                        SendText(msg.Chat.Id, $"Теперь подсчёт денег будет вестись с {wordsMsgText[1]} уровня (есть погрешность)", "Начало");
                                        StreamWrite(msg.Chat.Username,int.Parse(wordsMsgText[1]));
                                    }
                                }
                                }
                            }
                    } else
                    {
                        switch (msg.Text)
                        {
                            case "Обновить уровни":

                                if (msg.Chat.Username == Admin)
                                {
                                    StreamRead();
                                    SendText(msg.Chat.Id, "Уровни пользователей обновлены.", "Начало");
                                } else
                                {
                                    SendText(msg.Chat.Id, ErrorAdmin, "Начало");
                                }
                                break;
                            case "Начало":
                                SendText(msg.Chat.Id, "Что хочешь узнать?", "Начало");
                                break;
                            case "Маршруты":
                                SendText(msg.Chat.Id, "В каком городе хочешь узнать инфу про маршруты?", "Маршруты");
                                break;
                            case "Уровень":
                                SendText(msg.Chat.Id, $"Напишите боту команду: [Уровень [число] !]. Ваш текущий уровень: {WhatUser(msg.Chat.Username)}", "Начало");
                                break;
                            case "Выгодные маршруты":
                                SendText(msg.Chat.Id, "По чему хотите посмотреть список выгодных маршрутов?", "Выгодные маршруты");
                                break;
                            case "По опыту":
                                SendText(msg.Chat.Id, $"{Routes("Опыт",msg.Chat.Username)}", "Начало");
                                break;
                            case "По деньгам":
                                SendText(msg.Chat.Id, $"{Routes("Деньги", msg.Chat.Username)}", "Начало");
                                break;
                            case "Назад":
                                SendText(msg.Chat.Id, "Ладушки", "Маршруты");
                                break;
                            case "Маршруты: Приволжск":
                                SendText(msg.Chat.Id, "Вот тебе Маршруты: Приволжск", "Приволжск");
                                break;
                            case "Маршруты: Мирный":
                                SendText(msg.Chat.Id, "Вот тебе Маршруты: Мирный", "Мирный");
                                break;
                            case "Маршруты: Невский":
                                SendText(msg.Chat.Id, "Вот тебе Маршруты: Невский", "Невский");
                                break;
                            case "Маршруты: Жуковский":
                                SendText(msg.Chat.Id, "Вот тебе Маршруты: Жуковский", "Жуковский");
                                break;
                            case "Маршруты: Волчанск":
                                SendText(msg.Chat.Id, "Вот тебе Маршруты: Волчанск", "Волчанск");
                                break;
                            case "Маршруты: ПД1":
                                SendText(msg.Chat.Id, "Вот тебе Маршруты: ПД1", "ПД1");
                                break;
                            case "Маршруты: ПД2":
                                SendText(msg.Chat.Id, "Вот тебе Маршруты: ПД2", "ПД2");
                                break;
                            default:
                                SendText(msg.Chat.Id, "Команда не найдена, либо неправильно введена. Выберите из предложенных: ", "Начало");
                                break;
                        }
                    }
                }
            }
        }
        
    }
}
