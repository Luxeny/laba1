using System;

class Program
{
    static void Main()
    {
        double a = 10;
        double b = 8;
        double L = 20;
        double r = 3;
        double l = 15;

        double v1 = a * b * L;
        double v2 = 3.14 * r * r * l;
        double waste = v1 - v2;
        double percent = (waste / v1) * 100;

        Console.WriteLine("Объем исходного: " + v1);
        Console.WriteLine("Объем выточенного: " + v2);
        Console.WriteLine("Отходы: " + waste);
        Console.WriteLine("Процент: " + percent + "%");
    }
}