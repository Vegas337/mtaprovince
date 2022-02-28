using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;


namespace MTAProvince
{
    internal class HelloButton
    {
        public static IReplyMarkup GetButtons(string what)
        {
            if (what == "Начало")
            {
                return new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Маршруты" }, new KeyboardButton { Text = "Выгодные маршруты" }},
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Уровень" }, new KeyboardButton { Text = "Обновить уровни" }},
                }
                };
            }
            else if (what == "Маршруты")
            {
                return new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Маршруты: Приволжск"}, new KeyboardButton { Text = "Маршруты: Мирный" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Маршруты: Невский" }, new KeyboardButton { Text = "Маршруты: Жуковский" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Маршруты: Волчанск" }, new KeyboardButton { Text = "Маршруты: ПД1" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Маршруты: ПД2" }, new KeyboardButton { Text = "Начало" } },
                }
                };
            }
            else if (what == "Выгодные маршруты")
            {
                return new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "По опыту"}, new KeyboardButton { Text = "По деньгам" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Начало" } },
                }
                };
            }
            else if (what == "Приволжск")
            {
                return new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Приволжск Автобус 21 !" }, new KeyboardButton { Text = "Приволжск Автобус 30 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Приволжск Автобус 34 !" }, new KeyboardButton { Text = "Приволжск Автобус 38 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Приволжск Автобус 55 !" }, new KeyboardButton { Text = "Приволжск Троллейбус 8 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Приволжск Троллейбус 10 !" }, new KeyboardButton { Text = "Приволжск Троллейбус 15 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Назад" } },
                }
                };
            }
            else if (what == "Невский")
            {
                return new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Невский Автобус 1 !" }, new KeyboardButton { Text = "Невский Автобус 18 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Невский Автобус 47 !" }, new KeyboardButton { Text = "Невский Автобус 145 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Невский Автобус 400 !" }, new KeyboardButton { Text = "Невский Автобус 564 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Невский Автобус 632 !" }, new KeyboardButton { Text = "Невский Троллейбус 7 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Невский Троллейбус 11 !" }, new KeyboardButton { Text = "Невский Троллейбус 16 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Невский Трамвай 43 !" }, new KeyboardButton { Text = "Невский Трамвай 52 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Невский Трамвай 64 !" }, new KeyboardButton { Text = "Невский Трамвай 100 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Назад" } },
                }
                };
            }
            else if (what == "Мирный")
            {
                return new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Мирный Автобус 71 !"}, new KeyboardButton { Text = "Мирный Автобус 79 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Мирный Автобус 82 !" }, new KeyboardButton { Text = "Мирный Автобус 90 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Мирный Автобус 126 !" }, new KeyboardButton { Text = "Мирный Троллейбус 1 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Мирный Троллейбус 2 !" }, new KeyboardButton { Text = "Мирный Троллейбус 3 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Мирный Трамвай 3 !" }, new KeyboardButton { Text = "Мирный Трамвай 5 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Мирный Трамвай 8 !" }, new KeyboardButton { Text = "Мирный Трамвай 15 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Назад" } },
                }
                };
            }
            else if (what == "Волчанск")
            {
                return new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Волчанск Автобус 132 !"}, new KeyboardButton { Text = "Волчанск Автобус 476 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Назад" } },
                }
                };
            }
            else if (what == "Жуковский")
            {
                return new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Жуковский Автобус 145 !"}, new KeyboardButton { Text = "Жуковский Автобус 171 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Жуковский Автобус 181 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Назад" } },
                }
                };
            }
            else if (what == "ПД1")
            {
                return new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "ПД1 Трамвай 2 !"}, new KeyboardButton { Text = "ПД1 Трамвай 13 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "ПД1 Трамвай 24 !" }, new KeyboardButton { Text = "ПД1 Трамвай 25 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Назад" } },
                }
                };
            }
            else if (what == "ПД2")
            {
                return new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "ПД2 Трамвай 7 !" }, new KeyboardButton { Text = "ПД2 Трамвай 8 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "ПД2 Трамвай 19 !" }, new KeyboardButton { Text = "ПД2 Трамвай 22 !" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Назад" } },
                }
                };
            }
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
            {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Начало начал" } }
                }
            };
        }
    }
}
