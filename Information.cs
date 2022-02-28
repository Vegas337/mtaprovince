using System;
using static MTAProvince.WriteRead;

namespace MTAProvince
{
    internal class Information
    {
        // 1 - Мирный 2 - Приволжск 3 - Невский 4 - Жуковский 5 - Волчанск
        // Р - рейс / Ч - час
        // Город - Номер - Длительность(р) - Оплата(р) - Рейсы(ч) - Оплата(ч) - Остановки(р) - Опыт(р) - Светофоры(р)
        public static string Info = "";
        public static string InfoPribilno = "";

        public static int Vegas337_ = 4; // Vegas
        public static int BLACK_KANEKIF_ = 4; //MAJOR

        static double total = 0;

        static int UserLevel;
        public static double[] WhatPlus = { 0, 0, 0, 0, 1.3, 1.25, 1.2, 1.175, 1.145, 1.1, 1.09, 1.06, 1.06, 1.05, 1.04, 1.04, 1.03, 1.02, 1.01, 1.009, 1.008, 1.007, 1.0065, 1.006, 1.055, 1.055, 1.05, 1.45, 1.4, 1.4 };

        public static int WhatUser (string user)
        {
            if (user == "Vegas337")
            {
                return Vegas337_;
            } else if (user == "BLACK_KANEKIF")
            {
                return BLACK_KANEKIF_;
            }
            return 205;
        }

        public static double MathAmount (int amount, string transport, string user)
        {
            if (user == "Vegas337") { UserLevel = Vegas337_; } else if (user == "BLACK_KANEKIF") { UserLevel = BLACK_KANEKIF_; }
            if (transport == "Автобус")
            {
                if (UserLevel > 4)
                {
                    total = amount;
                    int levelPlus = UserLevel;
                    for (int i = UserLevel; i > 4; i--)
                    {
                        total = total * WhatPlus[levelPlus];
                        levelPlus = levelPlus - 1;
                    }

                }else
                {
                    return amount;
                }
            } else if (transport == "Троллейбус" | transport == "Трамвай")
            {
                if (UserLevel > 5)
                {
                    total = amount;
                    int levelPlus = UserLevel;
                    for (int i = UserLevel; i > 5; i--)
                    {
                        total = total * WhatPlus[levelPlus];
                        levelPlus = levelPlus - 1;
                    }
                }else
                {
                    return amount;
                }
            }
            return Math.Round(total);
        }

        public static string Routes (string what, string user)
        {
            int UserLevel;
            if (user == "Vegas337") { UserLevel = Vegas337_; } else if (user == "BLACK_KANEKIF") { UserLevel = BLACK_KANEKIF_; }
            if (what == "Опыт")
            {
                InfoPribilno = 
($@"№632,Невский Автобус - 132 опыта/час
№476,Волчанск Автобус - 112 опыта/час
№1,Мирный Троллейбус - 135 опыта/час
№181,Жуковский Автобус - 132 опыта/час
№7,Приволжск Троллейбус - 135 опыта/час
№25,ПД1 Трамвай - 120 опыта/час
№15,ПД2 Трамвай - 115 опыта/час");
            }else if (what == "Деньги")
            {
                InfoPribilno =
($@"№16,Невский Троллейбус - 38289*({MathAmount(38289, "Троллейбус", user)}**) руб/час
№82,Мирный Автобус - 36810*({MathAmount(36810, "Автобус", user)}**) руб/час
№10,Приволжск Троллейбус - 40572*({MathAmount(40572, "Троллейбус", user)}**) руб/час
№25,ПД1 Трамвай - 37640*({MathAmount(37640, "Трамвай", user)}**) руб/час
№7,ПД2 Трамвай - 37455*({MathAmount(37455, "Трамвай", user)}**) руб/час
* Указаны данные с 5 уровня
** Данные с учётом вашего уровня");
            }
            return InfoPribilno;
        }

        public static int WhatLevel (string user, int level)
        {
            if (user == "Vegas337")
            {
                Vegas337_ = level;
                StreamWrite("Vegas337", level);
                return 201;
            }
            else if (user == "BLACK_KANEKIF")
            {
                BLACK_KANEKIF_ = level;
                StreamWrite("BLACK_KANEKIF", level);
                return 201;
            }
            else
            {
                return 202;
            }
            //return 505000505;
        }

        public static int Output(int numberBus, string city, double time, int pay, int vault, int payHour, int stops, int exp, int light,string user, string transport)
        {
            if (user == "Vegas337")
            {
                Info = ($@"Номер: {numberBus}, {city}
Время: {time} /мин
Оплата: {pay} руб/рейс
Оплата: {MathAmount(payHour,transport,user)} руб/час
Рейсов: {vault} рейсов/час
Опыт: {exp} опыта/рейс
Остановок: {stops} шт/рейс
Светофоров: {light} шт/рейс
Опыт: {vault * exp} опыта/час
** Учитывая Ваш указанный лвл");
            }else
            {
                return 203;
            }
            return 204;
        }

        //public static int Level

        public static int Numbers(string city, string Transport, int number, string user)
        {


            if (city == "Приволжск")
            {
                if (Transport == "Автобус")
                {
                    if (number == 21) { return Output(21, "ПТЭЦ - Дом Культуры", 9, 4019, 6, 24114, 17, 18, 12, user, Transport); } //108
                    else if (number == 30) { return Output(30, "Дом Культуры - Завод ЖБК", 8, 3676, 7, 25732, 15, 14, 12, user, Transport); }//98
                    else if (number == 34) { return Output(34, "Ж/Д Вокзал - Завод ЖБК", 9, 5863, 4, 23452, 26, 24, 18, user, Transport); }//96
                    else if (number == 38) { return Output(38, "Автостанция - Больница", 9, 2963, 9, 26667, 17, 13, 6, user, Transport); }//117
                    else if (number == 55) { return Output(55, "Автостанция - ПГТ Жуковский", 9, 3674, 7, 25718, 12, 12, 12, user, Transport); }//84
                }
                else if (Transport == "Троллейбус")
                {
                    if (number == 8) { return Output(8, "Вокзал - ПТЭЦ", 6.20, 4391, 9, 39519, 12, 13, 6, user, Transport); }//117
                    else if (number == 10) { return Output(10, "Безымянский Рынок - ПТЭЦ", 6.30, 4508, 9, 40572, 13, 13, 10, user, Transport); }//117
                    else if (number == 15) { return Output(15, "Троллейбусное депо - Ж/Д Вокзал", 11, 6599, 5, 32995, 21, 27, 15, user, Transport); }//135
                }
            }
            else if (city == "ПД1")
            {
                if (Transport == "Трамвай")
                {
                    if (number == 2) { return Output(2, "Трамвайное Депо - Завод ЖБК", 4.30, 2782, 13, 36166, 5, 9, 0, user, Transport); }//117
                    else if (number == 13) { return Output(13, "ПТЭЦ - Завод ЖБК", 24, 14268, 2, 28536, 33, 46, 24, user, Transport); }//92
                    else if (number == 24) { return Output(24, "Завод ЖБК - Ж/Д Вокзал", 28, 16623, 2, 33246, 37, 55, 32, user, Transport); }//110
                    else if (number == 25) { return Output(25, "Трамвайное Депо - Гоночный трек", 15, 9410, 4, 37640, 19, 30, 16, user, Transport); }//120
                }
            }
            else if (city == "ПД2")
            {
                if (Transport == "Трамвай")
                {
                    if (number == 7) { return Output(7, "Трамвайное депо №2 - Трамвайное депо №1", 12, 7419, 5, 37455, 14, 23, 10, user, Transport); }//115
                    else if (number == 8) { return Output(8, "Трамвайное депо №2 - Ж/Д вокзал", 9, 3745, 10, 37450, 7, 11, 8, user, Transport); }//110
                    else if (number == 19) { return Output(19, "Ж/Д вокзал - Электродепо", 9, 11593, 3, 34779, 25, 37, 19, user, Transport); }//111
                    else if (number == 22) { return Output(22, "Электродепо - Завод ЖБК", 9, 15445, 2, 30890, 35, 52, 30, user, Transport); }//104
                }
            }

            else if (city == "Жуковский")
            {
                if (Transport == "Автобус")
                {
                    if (number == 145) { return Output(145, "ПГТ Жуковский - АЭС МирнАтом", 5, 2332, 12, 27984, 8, 9, 0, user, Transport); }//108
                    else if (number == 171) { return Output(171, "ПГТ Жуковский - Деревня Горная", 7, 3210, 8, 25680, 8, 13, 0, user, Transport); }//104
                    else if (number == 181) { return Output(181, "ПГТ Жуковский - Деревня Водино", 7, 3372, 8, 26976, 13, 14, 0, user, Transport); }//112
                }
            }

            else if (city == "Мирный")
            {
                if (Transport == "Автобус")
                {
                    if (number == 71) { return Output(71, "Автостанция №1 - Аэродром ЛАП", 13, 5861, 4, 23444, 19, 25, 13, user, Transport); }//100
                    else if (number == 79) { return Output(79, "Автостанция №2 - Стадион Арена Мирный", 9.30, 4308, 6, 25848, 16, 18, 14, user, Transport); }//108
                    else if (number == 82) { return Output(82, "Автостанция №1 - ТРК Сити Парк Град", 10.30, 4719, 6, 28314, 19, 20, 16, user, Transport); }//120
                    else if (number == 90) { return Output(90, "Ж/Д Вокзал - Шахта", 10.10, 4582, 6, 27492, 16, 19, 19, user, Transport); }//114
                    else if (number == 126) { return Output(126, "Ж/Д Вокзал г. Мирный - Ж/Д Вокзал г. Приволжск", 14, 6311, 4, 25244, 14, 27, 10, user, Transport); }//108
                }
                else if (Transport == "Троллейбус")
                {
                    if (number == 1) { return Output(1, "Троллейбусное депо - Гостиница Космос", 12, 7134, 5, 35670, 23, 27, 21, user, Transport); }//135
                    else if (number == 2) { return Output(2, "Кольцевой: Завод Экран - Ж/Д Вокзал - Бизнес центр - Завод Экран", 6, 3567, 10, 35670, 10, 12, 7, user, Transport); }//120
                    else if (number == 3) { return Output(3, "Троллейбусное Депо - ЖД Вокзал", 12.30, 7316, 5, 36580, 20, 25, 15, user, Transport); }//125
                }
                else if (Transport == "Трамвай")
                {
                    if (number == 3) { return Output(3, "Приволжское шоссе - МКП АТП", 10, 5942, 6, 35652, 14, 19, 7, user, Transport); }//114
                    else if (number == 5) { return Output(5, "Приволжское шоссе - Ж/Д Вокзал", 17, 10298, 3, 30894, 20, 34, 18, user, Transport); }//102
                    else if (number == 8) { return Output(8, "Шахта - Ж/Д Вокзал", 30, 17836, 2, 35672, 31, 58, 8, user, Transport); }//116
                    else if (number == 15) { return Output(15, "Приволжское шоссе - Арена Мирный", 15, 8918, 4, 35672, 20, 27, 8, user, Transport); }//108
                }

            }
            else if (city == "Волчанск")
            {
                if (Transport == "Автобус")
                {
                    if (number == 132) { return Output(132, "Волчанск - Жуковский", 9.30, 4357, 6, 26142, 12, 19, 0, user, Transport); }//114
                    else if (number == 476) { return Output(476, "Волчанск - Невский", 8, 3978, 7, 27846, 10, 16, 15, user, Transport); }//112
                }
            }

            else if (city == "Невский")
            {
                if (Transport == "Автобус")
                {
                    if (number == 1) { return Output(1, "M1 Кольцевой (По линии метро)", 11.10, 4664, 5, 23320, 22, 20, 19, user, Transport); }//100
                    else if (number == 18) { return Output(18, "Речной Вокзал - Табачный завод", 18, 8232, 3, 24696, 32, 36, 34, user, Transport); }//108
                    else if (number == 47) { return Output(47, "Васильевский остров - Центральные склады", 7, 3210, 8, 25680, 10, 11, 9, user, Transport); }//88
                    else if (number == 145) { return Output(145, "Автобусный парк - Невская ТЭЦ", 16, 7340, 3, 22020, 33, 31, 27, user, Transport); }//93
                    else if (number == 400) { return Output(400, "Кольцевой - ПКАД", 24, 11524, 2, 23048, 18, 56, 28, user, Transport); }//112
                    else if (number == 564) { return Output(564, "Невский - Приволжск", 18, 8232, 3, 24696, 12, 36, 40, user, Transport); }//108
                    else if (number == 632) { return Output(632, "Невский - Мирный", 18.30, 8509, 3, 25527, 16, 44, 35, user, Transport); }//132
                }
                else if (Transport == "Троллейбус")
                {
                    if (number == 7) { return Output(7, "ЖД Вокзал - Васильевский остров", 8, 4815, 7, 33705, 14, 15, 10, user, Transport); }//105
                    else if (number == 11) { return Output(11, "Депо (МУП ГЭТ) - Васильевский остров", 12, 7491, 5, 37455, 21, 24, 16, user, Transport); }//120
                    else if (number == 16) { return Output(16, "Депо (МУП ГЭТ) - Речной вокзал", 19.30, 12763, 3, 38289, 37, 42, 30, user, Transport); }//126
                }
                else if (Transport == "Трамвай")
                {
                    if (number == 43) { return Output(43, "Речной Вокзал - Станция Метро Казанская", 20, 11950, 3, 35850, 31, 40, 30, user, Transport); }//120
                    else if (number == 52) { return Output(52, "Речной Вокзал - Трамвайное Депо", 15, 8918, 4, 35672, 15, 30, 14, user, Transport); }//120
                    else if (number == 64) { return Output(64, "Трамвайное Депо - Станция метро Казанская", 11, 6599, 5, 32995, 15, 19, 16, user, Transport); }//95
                    else if (number == 100) { return Output(100, "Красновосходская Площадь - Трамвайное Депо", 6.30, 3692, 9, 33228, 6, 12, 6, user, Transport); }//108
                }
            }
            return 206;
        }

    }
}
