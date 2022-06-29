using System;

Blackjack obj = new Blackjack(); //создаём объект класса

int pos; //переменная для выбора режима

Console.WriteLine("Добро пожаловать в блэкджэк!\n");
Console.WriteLine("Выберите режим: ");
Console.WriteLine("-----------------------");
Console.WriteLine("  1) С игроком");
Console.WriteLine("  2) С \"компьютером\"");
Console.WriteLine("-----------------------\n");

Console.Write("> ");
pos = Convert.ToInt32(Console.ReadLine());

if (pos == 1)
{
    obj.fill_array();
    obj.play();
}

if (pos == 2)
{
    obj.fill_array();
    obj.play_computer();
}

else
{
    Console.WriteLine("Введите значение правильно!");
}

class Blackjack //класс с методами игры
{
    private int[] arr = new int[32];
    public void fill_array() //метод заполнения массива рандомными значениями
    {
        Random random = new Random();

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(2, 11);
        }

        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
    public void play() //метод с логикой игры (2 игрока)
    {
        int countP1 = 0; //сумма очков игрока №1
        int countP2 = 0; //сумма очков игроа №2
        int cardLimit = 0; //счетчик карт
        int game; //выбор карты
        char tmp; //выбор действия (y/n)

        while (true)
        {
            while (true) //цикл хода 1 игрока
            {
                Console.WriteLine("Ходит первый игрок\n");
                Console.Write("Выберите карту (1 - 32): ");

                game = Convert.ToInt32(Console.ReadLine()); //выбор карты
                countP1 += arr[game-1]; //прибавляем очки
                arr[game-1] = 0; //обнуляем использованную карту

                Console.Write("Возьмёте ещё карту? (y/n): ");
                tmp = Convert.ToChar(Console.ReadLine());

                if (tmp == 'y' && cardLimit < 2)
                {
                    cardLimit++;
                    continue;
                }
                if (tmp == 'n')
                {
                    break;
                }
                if (cardLimit >= 2)
                {
                    Console.WriteLine("Лимит карт исчерпан (3 за ход)");
                    cardLimit = 0; //обнуляем лимит карт
                    break;
                }
                else
                {
                    break;
                }
            }
            if (countP1 == 21)
            {
                Console.WriteLine("Победил игрок 1");
                Console.WriteLine($"Кол - во очков: {countP1}");
                break;
            }

            if (countP1 > 21)
            {
                Console.WriteLine("Игрок 1 проиграл");
                Console.WriteLine($"Кол - во очков: {countP1}");
                break;
            }

            while (true)
            {
                Console.WriteLine("Ходит второй игрок\n");
                Console.Write("Выберите карту (1 - 32): ");

                game = Convert.ToInt32(Console.ReadLine());
                countP2 += arr[game - 1];
                arr[game - 1] = 0;

                Console.Write("Возьмёте ещё карту? (y/n): ");
                tmp = Convert.ToChar(Console.ReadLine());

                if (tmp == 'y' && cardLimit < 2)
                {
                    cardLimit++;
                    continue;
                }
                if (tmp == 'n')
                {
                    break;
                }
                if (cardLimit >= 2)
                {
                    Console.WriteLine("Лимит карт исчерпан (3 за ход)");
                    cardLimit = 0; //обнуляем лимит карт
                    break;
                }
                else
                {
                    break;
                }
            }
            
            if (countP2 == 21)
            {
                Console.WriteLine("Победил игрок 2");
                Console.WriteLine($"Кол - во очков: {countP2}");
                break;
            }
            
            if (countP2 > 21)
            {
                Console.WriteLine("Игрок 2 проиграл");
                Console.WriteLine($"Кол - во очков: {countP2}");
                break;
            }
        }
    }
    public void play_computer() //метод с логикой игры (с компьютером)
    {
        int playerCount = 0; //сумма очков игрока
        int computerCount = 0; //сумма очков компьютера
        int cardLimit = 0; //лимит карт
        int game; //выбор карты
        int computerTmp; //y/n
        char playerTmp; //y/n

        Random random = new Random();
        Random comp = new Random();

        while (true)
        {
            while (true)
            {
                Console.WriteLine("\nВаш ход\n");
                Console.Write("Выберите карту (1 - 32): ");

                game = Convert.ToInt32(Console.ReadLine());
                playerCount += arr[game - 1]; //прибавляем очки
                arr[game - 1] = 0; //обнуляем карту

                Console.Write("Возьмёте ещё карту? (y/n): ");
                playerTmp = Convert.ToChar(Console.ReadLine());

                if (playerTmp == 'y' && cardLimit < 2)
                {
                    cardLimit++;
                    continue;
                }
                if (playerTmp == 'n')
                {
                    break;
                }
                if (cardLimit >= 2)
                {
                    Console.WriteLine("Лимит карт исчерпан (3 за ход)");
                    cardLimit = 0;
                    break;
                }
                else
                {
                    break;
                }
            }
            if (cardLimit == 21)
            {
                Console.WriteLine("Вы победили!");
                Console.WriteLine($"Кол - во очков: {playerCount}");
                break;
            }

            if (playerCount > 21)
            {
                Console.WriteLine("Вы проиграли!");
                Console.WriteLine($"Кол - во очков: {playerCount}");
                break;
            }

            while (true)
            {
                Console.WriteLine("Ход компьютера\n");
                Thread.Sleep(200);
                Console.WriteLine("Компьютер сделал выбор!");

                game = random.Next(0, 31); //случайная карта
                computerCount += arr[game]; //прибавляем очки
                arr[game] = 0; //обнуляем карту

                Console.Write("Возьмёте ещё карту? (y/n): ");
                Thread.Sleep(200); //задержка
                computerTmp = comp.Next(1, 10); //выбор действия

                if (computerTmp <= 5 && cardLimit < 2)
                {
                    Console.WriteLine("Компьютер взял ещё карту");
                    cardLimit++;
                    continue;
                }
                if (computerTmp > 5)
                {
                    Console.WriteLine("Компьютер не взял карту");
                    break;
                }
                if (cardLimit >= 2)
                {
                    Console.WriteLine("Лимит карт исчерпан (3 за ход)");
                    cardLimit = 0;
                    break;
                }
                else
                {
                    break;
                }
            }

            if (computerCount == 21)
            {
                Console.WriteLine("Победил компьютер!");
                Console.WriteLine($"Кол - во очков: {computerCount}");
                break;
            }

            if (computerCount > 21)
            {
                Console.WriteLine("Компьютер проиграл!");
                Console.WriteLine($"Кол - во очков: {computerCount}");
                break;
            }
        }
    }
}