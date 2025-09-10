using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class MainProgram
{
    static void Main()
    {
        WriteLine("Выберите программу:");
        WriteLine("1 - Расчёт цилиндра");
        WriteLine("2 - Анализ животных зоопарка");
        Write("Ваш выбор: ");

        var choice = ReadLine();

        switch (choice)
        {
            case "1":
                RunCylinderProgram();
                break;
            case "2":
                RunZooProgram();
                break;
            default:
                WriteLine("неверно!");
                break;
        }
    }

    static void RunCylinderProgram()
    {
        WriteLine("\nРасчёт обрабокти цилиндра");
        WriteLine("=========================================");

        double a = GetValidInput("Введите длину ребра a основания (a > 0): ");
        double b = GetValidInput("Введите длину ребра b основания (b > 0): ");
        double L = GetValidInput("Введите длину исходного цилиндра L (L > 0): ");
        double r = GetValidInput("Введите радиус выточенного цилиндра r (r > 0): ");
        double l = GetValidInput("Введите длину выточенного цилиндра l (l > 0): ");

        if (r >= a / 2)
        {
            WriteLine($"Ошибка: радиус r ({r}) должен быть меньше a/2 ({a / 2})");
            return;
        }

        if (r >= b / 2)
        {
            WriteLine($"Ошибка: радиус r ({r}) должен быть меньше b/2 ({b / 2})");
            return;
        }

        if (l >= L)
        {
            WriteLine($"Ошибка: длина l ({l}) должна быть меньше L ({L})");
            return;
        }

        double originalVolume = a * b * L;
        double drilledVolume = Math.PI * Math.Pow(r, 2) * l;
        double wasteVolume = originalVolume - drilledVolume;
        double wastePercentage = (wasteVolume / originalVolume) * 100;

        WriteLine($"\nРезультаты:");
        WriteLine($"Исходный объем: {originalVolume:F2}");
        WriteLine($"Выточенный объем: {drilledVolume:F2}");
        WriteLine($"Отходы: {wasteVolume:F2}");
        WriteLine($"Процент отходов: {wastePercentage:F1}%");
    }

    static void RunZooProgram()
    {
        var animals = new List<Animal>
        {
            new Animal("Триппи Троппи", 200, 10, "Мясо"),
            new Animal("Тралалеро Тралала", 180, 8, "Мясо"),
            new Animal("Лирили Ларила", 5000, 150, "Трава"),
            new Animal("Пипи Потато", 70, 3, "Мясо"),
            new Animal("Бобрито Бандито", 190, 9, "Мясо"),
            new Animal("Чимпанцини Бананини", 300, 20, "Трава")
        };

        var meatEaters = animals.Where(a => a.FoodType == "Мясо").ToList();
        if (meatEaters.Count == 0)
        {
            WriteLine("Ошибка: нет животных, потребляющих мясо");
            return;
        }

        WriteLine("\nХищники (едят мясо):");
        WriteLine("====================");
        foreach (var animal in meatEaters)
        {
            WriteLine($"{animal.Name} - {animal.Weight}кг, ест {animal.DailyConsumption}кг/день");
        }

        var maxConsumer = animals
            .OrderByDescending(a => a.DailyConsumption / a.Weight)
            .First();

        double ratio = maxConsumer.DailyConsumption / maxConsumer.Weight;

        WriteLine($"\nСамый прожорливый на 1кг веса:");
        WriteLine("==============================");
        WriteLine($"{maxConsumer.Name} - {ratio:F4}кг пищи на 1кг веса");
    }

    static double GetValidInput(string message)
    {
        double value;
        while (true)
        {
            Write(message);
            if (double.TryParse(ReadLine(), out value) && value > 0)
            {
                return value;
            }
            WriteLine($"Ошибка! Введите число больше 0");
        }
    }
}

class Animal
{
    public string Name { get; }
    public double Weight { get; }
    public double DailyConsumption { get; }
    public string FoodType { get; }

    public Animal(string name, double weight, double dailyConsumption, string foodType)
    {
        Name = name;
        Weight = weight;
        DailyConsumption = dailyConsumption;
        FoodType = foodType;
    }
}