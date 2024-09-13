namespace gonka;
using Utils;
using Models;

public class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Введите дистанцию гонки:");

        var step = 1000;
        var min = 1;
        var max = 10;

        Enumerable
            .Range(min, max)
            .Select(x => $"{x}) {x * step} м")
            .ToList()
            .ForEach(Console.WriteLine);

        var dist = Parsing.ParseInt(min, max) * 1000;
        Console.WriteLine($"Выбранная дистанция: {dist}");
        Console.WriteLine("Вид гонки:");
        var raceTypes = Enum.GetValues(typeof(RaceType)).Cast<RaceType>().ToArray();

        for (var i = 0; i < raceTypes.Length; i++)
        {
            Console.WriteLine($"{i + 1}) {EnumExtensions.GetDescription(raceTypes[i])})");
        }

        int raceTypeNum = Parsing.ParseInt(1, raceTypes.Length);
        RaceType raceType = raceTypes[raceTypeNum];

        // now choose transport
        //





    }
}
