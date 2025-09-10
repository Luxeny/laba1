using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите параметры:");

        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("L = ");
        double L = double.Parse(Console.ReadLine());

        Console.Write("r = ");
        double r = double.Parse(Console.ReadLine());

        Console.Write("l = ");
        double l = double.Parse(Console.ReadLine());

        if (r >= a / 2 || r >= b / 2 || l > L)
        {
            Console.WriteLine("Ошибка: не соблюдены условия задачи");
            return;
        }

        double originalVolume = a * b * L;
        double drilledVolume = Math.PI * Math.Pow(r, 2) * l;
        double wasteVolume = originalVolume - drilledVolume;
        double wastePercentage = (wasteVolume / originalVolume) * 100;

        Console.WriteLine($"\nРезультаты:");
        Console.WriteLine($"Исходный объем: {originalVolume:F2}");
        Console.WriteLine($"Выточенный объем: {drilledVolume:F2}");
        Console.WriteLine($"Отходы: {wasteVolume:F2}");
        Console.WriteLine($"Процент отходов: {wastePercentage:F1}%");
    }
}