using System;

class RockPaperScissors
{
    static void Main()
    {
        Console.WriteLine("Добро пожаловать в игру 'Камень, ножницы, бумага'!");

        while (true)
        {
            Console.WriteLine("\nВыберите одну из следующих опций:");
            Console.WriteLine("1. Камень");
            Console.WriteLine("2. Ножницы");
            Console.WriteLine("3. Бумага");
            Console.WriteLine("4. Выйти из игры");

            Console.Write("Ваш выбор: ");
            string input = Console.ReadLine();

            if (input == "4")
                break;

            if (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("Недопустимый ввод. Пожалуйста, выберите опцию от 1 до 4.");
                continue;
            }

            int playerChoice = int.Parse(input);
            int computerChoice = GetComputerChoice();

            Console.WriteLine("\nВы выбрали: " + GetChoiceName(playerChoice));
            Console.WriteLine("Бот выбрал: " + GetChoiceName(computerChoice));

            GameResult result = DetermineWinner(playerChoice, computerChoice);
            Console.WriteLine("Результат: " + GetResultMessage(result));
        }

        Console.WriteLine("\nСпасибо за игру. До свидания!");
    }

    static int GetComputerChoice()
    {
        Random random = new Random();
        return random.Next(1, 4);
    }

    static string GetChoiceName(int choice)
    {
        switch (choice)
        {
            case 1:
                return "Камень";
            case 2:
                return "Ножницы";
            case 3:
                return "Бумага";
            default:
                return "";
        }
    }

    static GameResult DetermineWinner(int playerChoice, int computerChoice)
    {
        if (playerChoice == computerChoice)
            return GameResult.Draw;

        if ((playerChoice == 1 && computerChoice == 2) ||
            (playerChoice == 2 && computerChoice == 3) ||
            (playerChoice == 3 && computerChoice == 1))
            return GameResult.PlayerWin;

        return GameResult.ComputerWin;
    }

    static string GetResultMessage(GameResult result)
    {
        switch (result)
        {
            case GameResult.Draw:
                return "Ничья!";
            case GameResult.PlayerWin:
                return "Вы победили!";
            case GameResult.ComputerWin:
                return "Бот победил!";
            default:
                return "";
        }
    }

    enum GameResult
    {
        Draw,
        PlayerWin,
        ComputerWin
    }
}
