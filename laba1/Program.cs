using System;
using static System.Console;

namespace CylinderProcessingCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Расчёт обработки цилиндрической заготовки");
            WriteLine("================(^. .^)===============");

            try
            {
                double a = GetValidInput("Введите длину ребра a основания (a > 0): ", 0);
                double b = GetValidInput("Введите длину ребра b основания (b > 0): ", 0);
                double L = GetValidInput("Введите длину исходного цилиндра L (L > 0): ", 0);
                double r = GetValidInput("Введите радиус выточенного цилиндра r (r > 0): ", 0);
                double l = GetValidInput("Введите длину выточенного цилиндра l (l > 0): ", 0);

                ValidateConditions(a, b, L, r, l);

                CalculateAndDisplayResults(a, b, L, r, l);
            }
            catch (Exception ex)
            {
                WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static double GetValidInput(string message, double minValue)
        {
            double value;
            while (true)
            {
                Write(message);
                if (double.TryParse(ReadLine(), out value) && value > minValue)
                {
                    return value;
                }
                WriteLine($"Ошибка! Введите число больше {minValue}");
            }
        }

        static void ValidateConditions(double a, double b, double L, double r, double l)
        {
            if (r >= a / 2)
                throw new ArgumentException($"Радиус r ({r}) должен быть меньше a/2 ({a / 2})");

            if (r >= b / 2)
                throw new ArgumentException($"Радиус r ({r}) должен быть меньше b/2 ({b / 2})");

            if (l >= L)
                throw new ArgumentException($"Длина l ({l}) должна быть меньше L ({L})");
        }

        static void CalculateAndDisplayResults(double a, double b, double L, double r, double l)
        {
            double originalVolume = a * b * L;
            double drilledVolume = Math.PI * Math.Pow(r, 2) * l;
            double wasteVolume = originalVolume - drilledVolume;
            double wastePercentage = (wasteVolume / originalVolume) * 100;
            double materialUsage = (drilledVolume / originalVolume) * 100;

            WriteLine("\n" + new string('=', 50));
            WriteLine("РЕЗУЛЬТАТЫ РАСЧЕТА");
            WriteLine(new string('=', 50));

            WriteLine($"Объём исходной заготовки: {originalVolume,10:F4}");
            WriteLine($"Объём готового изделия:   {drilledVolume,10:F4}");
            WriteLine($"Объём отходов:            {wasteVolume,10:F4}");
            WriteLine($"Процент отходов:          {wastePercentage,9:F2}%");
            WriteLine($"Использование материала:  {materialUsage,9:F2}%");

            WriteLine(new string('=', 50));
        }
    }
}